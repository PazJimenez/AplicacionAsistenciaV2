using AplicacionAsistencia.Controller;
using AplicacionAsistencia.Model;
using AplicacionAsistencia.View;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AplicacionAsistencia
{
    public partial class Form1 : Form
    {
        public AplicacionAsistenciaEntities conexion;
        public AsistenciaController asistenciaController;
        public ModificarUsuarioController modificarUsuarioController;
        public CrearUsuarioController crearUsuarioController;
        private string rutUsuario; // Variable para almacenar el rut
        private string rutActual; // Variable para almacenar el rut seleccionado
        public class Inasistencia
        {
            public string IdUsuario { get; set; }
            public string Nombre { get; set; }
            public DateTime Fecha { get; set; }
            public string Dia { get; set; }
        }


        // Constructor que recibe el rut desde el formulario de login
        public Form1(string rut)
        {
            InitializeComponent();
            conexion = new AplicacionAsistenciaEntities();
            asistenciaController = new AsistenciaController();
            crearUsuarioController = new CrearUsuarioController(); // Instancia del controlador
            modificarUsuarioController = new ModificarUsuarioController(); // Instancia del controlador
            var estados = new List<KeyValuePair<int, string>>()
                {
                    new KeyValuePair<int, string>(0, "Inactivo"),
                    new KeyValuePair<int, string>(1, "Activo")
                };

            comboBoxEstado.DataSource = estados;
            comboBoxEstado.DisplayMember = "Value"; // Muestra "Activo" o "Inactivo"
            comboBoxEstado.ValueMember = "Key"; // Usa 1 o 0 internamente
            comboBoxEstado.SelectedIndex = -1; // Para no tener nada seleccionado por defecto

            this.rutUsuario = rut; // Asignamos el rut recibido al campo local
            CargarRegiones();
            CargarRoles();
            CargarCargos();
            CargarTurnos();
            LimpiarFormularioCrearUsuario();
            CargarUsuariosEnGrid();
            comboBoxRegion.SelectedIndexChanged += comboBoxRegion_SelectedIndexChanged;
            comboBoxCiudad.SelectedIndexChanged += comboBoxCiudad_SelectedIndexChanged;


            // Asociar el evento Click del botón btnExportarCSV al método btnExportarCSV_Click
            this.btnExportarCSV.Click += new System.EventHandler(this.btnExportarCSV_Click);
        }

        // Evento para registrar la entrada
        private void button1_Click(object sender, EventArgs e)
        {
            if (!asistenciaController.EsDiaLaboral(DateTime.Now))
            {
                MessageBox.Show("No se puede registrar asistencia en días de descanso o festivos.");
                return;
            }

            // Obtener el turno del usuario
            var turnoUsuario = conexion.Turnos
                .Join(conexion.Usuarios,
                      t => t.IdTurno,
                      u => u.IdTurno,
                      (t, u) => new { Turno = t, Usuario = u })
                .FirstOrDefault(u => u.Usuario.IdUsuario == rutUsuario)?.Turno;

            if (turnoUsuario == null)
            {
                MessageBox.Show("No se pudo determinar el turno del usuario.");
                return;
            }

            DateTime horaInicioTurno = DateTime.Today.Add(turnoUsuario.HoraEntradaTurno ?? TimeSpan.Zero);
            TimeSpan tolerancia = TimeSpan.FromMinutes(15); // Tolerancia de 15 minutos


            if (DateTime.Now > horaInicioTurno.Add(tolerancia))
            {
                MessageBox.Show("Estás marcando entrada tarde.");
            }

            // Calcular horas trabajadas en la semana actual
            DateTime inicioSemana = DateTime.Now.Date.AddDays(-(int)DateTime.Now.DayOfWeek + 1); // Lunes
            DateTime finSemana = inicioSemana.AddDays(6); // Domingo

            var registrosSemana = conexion.Asistencia
                .Where(a => a.IdUsuario == rutUsuario
                            && a.HoraFechaEntrada >= inicioSemana
                            && a.HoraFechaEntrada <= finSemana)
                .ToList();

            var horasTrabajadasSemana = registrosSemana
                .Sum(a =>
                {
                    DateTime horaSalida = a.HoraFechaSalida ?? a.HoraFechaEntrada; // Si es null, usa HoraFechaEntrada
                    return (horaSalida - a.HoraFechaEntrada).TotalHours; // Calcula la diferencia
                });

            if (horasTrabajadasSemana >= 45)
            {
                MessageBox.Show("No se puede registrar la entrada: Se alcanzaron las 45 horas semanales permitidas por ley.");
                return;
            }

            // Verificar si ya existe una entrada registrada hoy para el usuario
            var yaRegistroEntrada = conexion.Asistencia
                .FirstOrDefault(a => a.IdUsuario == rutUsuario &&
                                     DbFunctions.TruncateTime(a.HoraFechaEntrada) == DateTime.Today);



            if (yaRegistroEntrada != null)
            {
                // Si ya existe una entrada registrada hoy, mostrar mensaje y evitar registrar otra
                MessageBox.Show("Ya has marcado tu entrada hoy. No puedes marcarla más de una vez al día.");
                return;
            }

            // Registrar la entrada
            Asistencia nuevaMarca = new Asistencia
            {
                IdUsuario = rutUsuario,
                HoraFechaEntrada = DateTime.Now
            };

            asistenciaController.MarcarEntrada(nuevaMarca);
            MessageBox.Show("Entrada registrada correctamente.");
        }


        // Evento para registrar la salida
        private void button2_Click(object sender, EventArgs e)
        {
            var ultimaMarca = conexion.Asistencia
                .Where(a => a.IdUsuario == rutUsuario && a.HoraFechaSalida == null)
                .OrderByDescending(a => a.HoraFechaEntrada)
                .FirstOrDefault();

            if (ultimaMarca != null)
            {
                var turnoUsuario = conexion.Turnos
                    .Join(conexion.Usuarios,
                          t => t.IdTurno,
                          u => u.IdTurno,
                          (t, u) => new { Turno = t, Usuario = u })
                    .FirstOrDefault(u => u.Usuario.IdUsuario == rutUsuario)?.Turno;

                if (turnoUsuario == null)
                {
                    MessageBox.Show("No se pudo determinar el turno del usuario.");
                    return;
                }

                // Comprobar si HoraSalidaTurno tiene valor
                if (turnoUsuario.HoraSalidaTurno.HasValue)
                {
                    TimeSpan horaSalidaEsperada = turnoUsuario.HoraSalidaTurno.Value; // Usamos .Value porque sabemos que tiene valor
                    DateTime horaSalida = DateTime.Now;

                    // Realizamos la operación de fecha fuera de la consulta LINQ
                    DateTime inicioSemana = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek + 1); // Lunes de esta semana
                    DateTime finSemana = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek + 7); // Domingo de esta semana

                    TimeSpan horasTrabajadasHoy = horaSalida - ultimaMarca.HoraFechaEntrada;

                    // Validar si la hora de salida es antes de la hora de salida esperada
                    if (horaSalida.TimeOfDay < horaSalidaEsperada)
                    {
                        MessageBox.Show($"Estás marcando la salida antes de la hora definida por tu turno. La hora de salida esperada es a las {horaSalidaEsperada.Hours:D2}:{horaSalidaEsperada.Minutes:D2}.");
                    }

                    // La salida se registra sin importar que esté antes de la hora esperada
                    ultimaMarca.HoraFechaSalida = horaSalida; // Se asigna la hora de salida

                    // Aquí ya tenemos una hora de salida válida. Podemos proceder con el resto de la lógica.

                    // Sumar las horas trabajadas durante la semana
                    double horasSemanales = conexion.Asistencia
                        .Where(a => a.IdUsuario == rutUsuario &&
                                    a.HoraFechaEntrada >= inicioSemana && // Lunes
                                    a.HoraFechaEntrada <= finSemana && // Domingo
                                    a.HoraFechaSalida != null)
                        .Sum(a => DbFunctions.DiffHours(a.HoraFechaEntrada, a.HoraFechaSalida)) ?? 0.0;

                    // Validar si excede las 10 horas diarias
                    if (horasTrabajadasHoy.TotalHours > 10)
                    {
                        horaSalida = ultimaMarca.HoraFechaEntrada.AddHours(10);
                        ultimaMarca.HoraFechaSalida = horaSalida;
                        MessageBox.Show("Se excedieron las 10 horas diarias permitidas. La salida se registró automáticamente a las 10 horas máximas.");
                    }

                    // Validar si excede las 45 horas semanales
                    horasSemanales += (ultimaMarca.HoraFechaSalida - ultimaMarca.HoraFechaEntrada)?.TotalHours ?? 0;

                    if (horasSemanales > 45)
                    {
                        double horasExcedidas = horasSemanales - 45;
                        ultimaMarca.HoraFechaSalida = ultimaMarca.HoraFechaSalida?.AddHours(-horasExcedidas);
                        MessageBox.Show($"Se excedieron las 45 horas semanales. La salida fue ajustada para cumplir con el límite semanal.");
                    }

                    // Guardar los cambios
                    conexion.SaveChanges();
                    MessageBox.Show($"Salida registrada correctamente. Total de horas trabajadas hoy: {horasTrabajadasHoy.TotalHours:F2}");
                }
                else
                {
                    MessageBox.Show("La hora de salida del turno no está definida.");
                }
            }
            else
            {
                MessageBox.Show("No se encontró una marca de entrada.");
            }
        }




        // Actualiza la hora en un label (si tienes uno en el formulario)
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHMSAMPM.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Pasar el RUT al nuevo formulario Form1
            Login login = new Login();
            login.Show();
        }

        private void CargarRegiones()
        {
            var regiones = crearUsuarioController.ObtenerRegionesConIds();
            comboBoxRegion.DataSource = regiones;
            comboBoxRegion.DisplayMember = "Nombre"; // Nombre visible
            comboBoxRegion.ValueMember = "Id";      // Valor oculto (ID)
            comboBoxCiudad.SelectedIndex = -1;
        }
        private void comboBoxRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRegion.SelectedValue != null)
            {
                int idRegionSeleccionada;
                if (int.TryParse(comboBoxRegion.SelectedValue.ToString(), out idRegionSeleccionada))
                {
                    var ciudades = crearUsuarioController.ObtenerCiudadesPorRegionId(idRegionSeleccionada);
                    comboBoxCiudad.DataSource = ciudades;
                    comboBoxCiudad.DisplayMember = "Nombre";
                    comboBoxCiudad.ValueMember = "Id";
                    comboBoxCiudad.SelectedIndex = -1; // Para no seleccionar ninguna ciudad automáticamente
                }
            }
        }
        private void comboBoxCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCiudad.SelectedValue != null)
            {
                int idCiudadSeleccionada;
                if (int.TryParse(comboBoxCiudad.SelectedValue.ToString(), out idCiudadSeleccionada))
                {
                    var comunas = crearUsuarioController.ObtenerComunasPorCiudadId(idCiudadSeleccionada);
                    comboBoxComuna.DataSource = comunas;
                    comboBoxComuna.DisplayMember = "Nombre";
                    comboBoxComuna.ValueMember = "Id";
                    comboBoxComuna.SelectedIndex = -1; // Para no seleccionar ninguna comuna automáticamente
                }
            }

        }
        private void CargarRoles()
        {
            var roles = crearUsuarioController.ObtenerRolesConIds();
            comboBoxRol.DataSource = roles;
            comboBoxRol.DisplayMember = "Nombre"; // Nombre visible
            comboBoxRol.ValueMember = "Id";      // Valor oculto (ID)
            comboBoxCiudad.SelectedIndex = -1;
        }

        private void CargarTurnos()
        {
            var turnos = crearUsuarioController.ObtenerTurnosConIds();
            comboBoxTurno.DataSource = turnos;
            comboBoxTurno.DisplayMember = "Nombre"; // Nombre visible
            comboBoxTurno.ValueMember = "Id";      // Valor oculto (ID)
            comboBoxCiudad.SelectedIndex = -1;
        }
        private void CargarCargos()
        {
            var cargos = crearUsuarioController.ObtenerCargosConIds();
            comboBoxCargo.DataSource = cargos;
            comboBoxCargo.DisplayMember = "Nombre"; // Nombre visible
            comboBoxCargo.ValueMember = "Id";      // Valor oculto (ID)
            comboBoxCiudad.SelectedIndex = -1;
        }
        public bool ValidarFormulario(bool esCreacion = true)
        {
            string rutNuevo = LimpiarFormatoRut(txtRutNuevo.Text);

            if (string.IsNullOrWhiteSpace(txtRutNuevo.Text) ||
                string.IsNullOrWhiteSpace(txtNombreNuevo.Text) ||
                string.IsNullOrWhiteSpace(txtCorreoNuevo.Text) ||
                string.IsNullOrWhiteSpace(txtDireccionNuevo.Text) ||
                comboBoxCiudad.SelectedIndex == -1 ||
                comboBoxComuna.SelectedIndex == -1 ||
                comboBoxRol.SelectedIndex == -1 ||
                comboBoxCargo.SelectedIndex == -1 ||
                comboBoxTurno.SelectedIndex == -1 ||
                comboBoxEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return false;
            }

            // Solo validar si el RUT ya existe al crear un nuevo usuario
            if (!esCreacion)
            {
                // Si el RUT ingresado no es igual al actual, verifica si ya existe
                if (rutNuevo != rutActual && VerificarRutExistente(rutNuevo))
                {
                    MessageBox.Show("El RUT ingresado ya está registrado.");
                    return false;
                }
            }
            Console.WriteLine($"RUT enviado para validación: {rutNuevo}");
            // Validar formato y validez del RUT chileno
            if (!EsRutValido(rutNuevo))
            {
                MessageBox.Show("El RUT ingresado no es válido. Asegúrate de usar el formato 12345678-9.");
                return false;
            }

            // Validar formato del correo
            if (!EsCorreoValido(txtCorreoNuevo.Text))
            {
                MessageBox.Show("El correo electrónico ingresado no es válido.");
                return false;
            }

            return true;
        }

        // Método para verificar si el RUT ya existe en la base de datos usando Entity Framework
        private bool VerificarRutExistente(string rutNuevo, string rutActual = null)
        {
            // Compara contra todos los usuarios, excepto el actual (en caso de edición)
            return conexion.Usuarios.Any(u => u.IdUsuario == rutNuevo && u.IdUsuario != rutActual);
        }
        private bool EsRutValido(string rut)
        {
            // Limpiar y validar formato básico
            rut = rut.Replace(".", "").ToUpper();
            if (!System.Text.RegularExpressions.Regex.IsMatch(rut, @"^\d{1,8}-[0-9K]$"))
                return false;

            // Separar la parte numérica y el DV ingresado
            string[] rutParts = rut.Split('-');
            string rutNumeros = rutParts[0];
            char dvIngresado = rutParts[1][0];

            int suma = 0;
            int multiplicador = 2;

            // Aplicar fórmula de módulo 11
            for (int i = rutNumeros.Length - 1; i >= 0; i--)
            {
                suma += int.Parse(rutNumeros[i].ToString()) * multiplicador;
                multiplicador = multiplicador == 7 ? 2 : multiplicador + 1;
            }

            int resto = 11 - (suma % 11);
            char dvCalculado = resto == 11 ? '0' : resto == 10 ? 'K' : (char)(resto + '0');

            // Depuración para verificar valores intermedios
            Console.WriteLine($"Parte numérica: {rutNumeros}, DV ingresado: {dvIngresado}, DV calculado: {dvCalculado}");

            // Comparar el DV ingresado con el calculado
            return dvIngresado == dvCalculado;
        }

        private string LimpiarFormatoRut(string rut)
        {
            return rut.Replace(".", "").Trim();
        }

        private bool EsCorreoValido(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
       {
            if (ValidarFormulario())
            {
                // Crear un nuevo usuario con los datos del formulario
                var nuevoUsuario = new Usuarios

                {
                    IdUsuario = LimpiarFormatoRut(txtRutNuevo.Text),
                    Nombre = txtNombreNuevo.Text.Trim(),
                    Correo = txtCorreoNuevo.Text.Trim(),
                    Direccion = txtDireccionNuevo.Text.Trim(),
                    Contraseña = txtContraseñaNuevo.Text.Trim(), // Contraseña agregada
                    IdComuna = (int)comboBoxComuna.SelectedValue,
                    IdRol = (int)comboBoxRol.SelectedValue,
                    IdCargo = (int)comboBoxCargo.SelectedValue,
                    IdTurno = (int)comboBoxTurno.SelectedValue,
                    // Convertir el valor del comboBoxEstado (0 o 1) a un valor booleano (false o true)
                    Activo = comboBoxEstado.SelectedValue.ToString() == "1" // Si es 1, activo será true, si no, será false
                };

                try
                {
                    // Llamar al controlador para guardar el usuario
                    crearUsuarioController.CrearUsuario(nuevoUsuario);
                    MessageBox.Show("Usuario creado exitosamente.");

                    // Recargar los usuarios en el DataGridView
                    CargarUsuariosEnGrid();

                    // Limpiar el formulario tras crear al usuario
                    LimpiarFormularioCrearUsuario();

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al crear el usuario: {ex.Message}");
                }
            }
       }

        private void CargarUsuariosEnGrid()
        {
            // Obtener los datos de los usuarios desde la base de datos
            var listaUsuarios = ObtenerTodosLosUsuarios();

            // Cargar los datos en el DataGridView
            dataGridViewUsuarios.DataSource = listaUsuarios;
            dataGridViewUsuarios.Columns["Contraseña"].Visible = false; // Ocultar la columna de contraseñas por seguridad
            dataGridViewUsuarios.AutoResizeColumns();
        }

        private void CargarDatosUsuario(string idUsuario)
        {
            // Actualizar la variable de clase con el RUT del usuario seleccionado
            rutActual = idUsuario;

            var usuario = conexion.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            Console.WriteLine($"RUT desde la base de datos: {usuario.IdUsuario}");
            try
            {
                if (usuario == null)
                {
                    MessageBox.Show("El usuario no existe.");
                    return;
                }

                // Cargar datos básicos
                txtRutNuevo.Text = usuario.IdUsuario;


                Console.WriteLine($"RUT cargado en el formulario: {txtRutNuevo.Text}");
                txtNombreNuevo.Text = usuario.Nombre;
                txtCorreoNuevo.Text = usuario.Correo;
                txtDireccionNuevo.Text = usuario.Direccion;
                txtContraseñaNuevo.Text = usuario.Contraseña;

                comboBoxRol.SelectedValue = usuario.IdRol;
                comboBoxCargo.SelectedValue = usuario.IdCargo;
                comboBoxTurno.SelectedValue = usuario.IdTurno;

                // Seleccionar Estado
                comboBoxEstado.SelectedIndex = usuario.Activo ? 1 : 0;

                // Seleccionar Región, Ciudad y Comuna
                if (usuario.IdComuna != null)
                {
                    var comuna = conexion.Comunas.FirstOrDefault(c => c.IdComuna == usuario.IdComuna);
                    if (comuna != null)
                    {
                        var ciudad = conexion.Ciudades.FirstOrDefault(ci => ci.IdCiudad == comuna.IdCiudad);
                        if (ciudad != null)
                        {
                            // Seleccionar Región
                            comboBoxRegion.SelectedValue = ciudad.IdRegion;

                            // Disparar el evento de cambio de Región para cargar ciudades
                            comboBoxRegion_SelectedIndexChanged(null, null);

                            // Seleccionar Ciudad
                            comboBoxCiudad.SelectedValue = ciudad.IdCiudad;

                            // Disparar el evento de cambio de Ciudad para cargar comunas
                            comboBoxCiudad_SelectedIndexChanged(null, null);

                            // Seleccionar Comuna
                            comboBoxComuna.SelectedValue = usuario.IdComuna;
                        }
                    }
                }
                else
                {
                    // Si no hay datos asociados, limpiar los ComboBox
                    comboBoxRegion.SelectedIndex = -1;
                    comboBoxCiudad.SelectedIndex = -1;
                    comboBoxComuna.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}");
            }
        }

        public class UsuarioConCiudadYRegion
        {
            public string IdUsuario { get; set; }
            public string Nombre { get; set; }
            public string Correo { get; set; }
            public string Direccion { get; set; }
            public string Contraseña { get; set; }
            public string Rol { get; set; } // Cambiado de int? a string
            public string Cargo { get; set; } // Cambiado de int? a string
            public string Comuna { get; set; } // Cambiado de int? a string
            public string Turno { get; set; } // Cambiado de int? a string
            public bool Activo { get; set; }
            public string Ciudad { get; set; }
            public string Region { get; set; }
        }

        private List<UsuarioConCiudadYRegion> ObtenerTodosLosUsuarios()
        {
            {
                // Traer los datos de la tabla Usuarios junto con los datos relacionados
                var listaUsuarios = conexion.Usuarios
                    .Include(u => u.Comunas)  // Incluir la relación con Comunas
                    .Include(u => u.Comunas.Ciudades)  // Incluir la relación con Ciudades
                    .Include(u => u.Comunas.Ciudades.Regiones)  // Incluir la relación con Regiones
                    .Include(u => u.Roles)  // Incluir la relación con Roles
                    .Include(u => u.Cargo)  // Incluir la relación con Cargos
                    .Include(u => u.Turnos)  // Incluir la relación con Turnos
                    .Select(u => new UsuarioConCiudadYRegion
                    {
                        IdUsuario = u.IdUsuario,
                        Nombre = u.Nombre,
                        Correo = u.Correo,
                        Direccion = u.Direccion,
                        Contraseña = u.Contraseña,
                        Rol = u.Roles.NombreRol,  // Obtener el nombre del Rol
                        Cargo = u.Cargo.NombreCargo,  // Obtener el nombre del Cargo
                        Comuna = u.Comunas.NombreComuna,  // Obtener el nombre de la Comuna
                        Ciudad = u.Comunas.Ciudades.NombreCiudad,  // Obtener el nombre de la Ciudad
                        Region = u.Comunas.Ciudades.Regiones.NombreRegion,  // Obtener el nombre de la Región
                        Turno = u.Turnos.NombreTurno,  // Obtener el nombre del Turno
                        Activo = u.Activo
                    })
                    .ToList();

                return listaUsuarios;
            }
        }


        private void LimpiarFormularioCrearUsuario()
        {
            txtRutNuevo.Clear();
            txtNombreNuevo.Clear();
            txtCorreoNuevo.Clear();
            txtDireccionNuevo.Clear();
            txtContraseñaNuevo.Clear();
            comboBoxRegion.SelectedIndex = -1;
            comboBoxCiudad.SelectedIndex = -1;
            comboBoxComuna.SelectedIndex = -1;
            comboBoxRol.SelectedIndex = -1;
            comboBoxCargo.SelectedIndex = -1;
            comboBoxTurno.SelectedIndex = -1;
            comboBoxEstado.SelectedIndex = -1;
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            dataGridViewReporte.Refresh();

            // Obtener las fechas seleccionadas por el usuario
            DateTime fechaInicio = dateTimePickerInicio.Value;
            DateTime fechaFin = dateTimePickerFin.Value;

            fechaInicio = fechaInicio.AddMilliseconds(-fechaInicio.Millisecond);
            fechaFin = fechaFin.AddMilliseconds(-fechaFin.Millisecond);

            Console.WriteLine($"Fecha de inicio seleccionada: {fechaInicio}");
            Console.WriteLine($"Fecha de fin seleccionada: {fechaFin}");

            if (comboBoxReporte.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un tipo de reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reporte = comboBoxReporte.SelectedItem.ToString();
            string rutFiltro = txtRutReporte.Text.Trim();  // Obtener el Rut desde el TextBox

            Console.WriteLine($"Reporte seleccionado: {reporte}");

            List<Asistencia> asistencias = asistenciaController.ObtenerEntradaSalida(fechaInicio, fechaFin);

            // Filtrar por Rut si se ha ingresado uno
            if (!string.IsNullOrEmpty(rutFiltro))
            {
                asistencias = asistencias.Where(a => a.Usuarios.IdUsuario == rutFiltro).ToList();
            }

            if (reporte == "Atrasos")
            {
                var atrasosFiltrados = asistencias.Where(a => a.HoraFechaEntrada.TimeOfDay > a.Usuarios.Turnos.HoraEntradaTurno).ToList();

                if (atrasosFiltrados.Count == 0)
                {
                    MessageBox.Show("No se encontraron resultados.");
                }

                Console.WriteLine($"Cantidad de registros encontrados: {atrasosFiltrados.Count}");

                dataGridViewReporte.DataSource = null;
                dataGridViewReporte.DataSource = atrasosFiltrados.Select(a => new
                {
                    Rut = a.Usuarios.IdUsuario,
                    Usuario = a.Usuarios.Nombre,
                    FechaHoraEntrada = a.HoraFechaEntrada,
                    TurnoEntrada = a.Usuarios.Turnos.HoraEntradaTurno,
                    MinutosAtraso = (a.HoraFechaEntrada.TimeOfDay - (a.Usuarios.Turnos.HoraEntradaTurno ?? TimeSpan.Zero)).TotalMinutes

                }).ToList();
            }
            else if (reporte == "Salida Adelantada")
            {
                var salidasAdelantadas = asistencias.Where(a => a.HoraFechaSalida.HasValue && a.HoraFechaSalida.Value.TimeOfDay < a.Usuarios.Turnos.HoraSalidaTurno).ToList();

                if (salidasAdelantadas.Count == 0)
                {
                    MessageBox.Show("No se encontraron resultados.");
                }
                Console.WriteLine($"Cantidad de registros encontrados: {salidasAdelantadas.Count}");

                dataGridViewReporte.DataSource = null;
                dataGridViewReporte.DataSource = salidasAdelantadas.Select(a => new
                {
                    Rut = a.Usuarios.IdUsuario,
                    Usuario = a.Usuarios.Nombre,
                    FechaHoraSalida = a.HoraFechaSalida,
                    TurnoSalida = a.Usuarios.Turnos.HoraSalidaTurno,
                    MinutosAdelanto = (a.Usuarios.Turnos.HoraSalidaTurno - a.HoraFechaSalida?.TimeOfDay ?? TimeSpan.Zero).TotalMinutes


                }).ToList();
            }
            else if (reporte == "Inasistencias")
            {
                // Obtener inasistencias con detalles de usuario
                var inasistencias = asistenciaController.ObtenerInasistencias(fechaInicio, fechaFin, rutFiltro);

                if (inasistencias.Count == 0)
                {
                    MessageBox.Show("No se encontraron inasistencias.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Console.WriteLine($"Cantidad de inasistencias encontradas: {inasistencias.Count}");

                // Mostrar inasistencias con detalles en el DataGridView
                dataGridViewReporte.DataSource = null;
                dataGridViewReporte.DataSource = inasistencias.Select(i => new
                {
                    Rut = i.IdUsuario,
                    Usuario = i.Nombre,
                    Fecha = i.Fecha.ToString("yyyy-MM-dd"),
                    Dia = i.Dia
                }).ToList();
            }

            else
            {
                if (asistencias.Count == 0)
                {
                    MessageBox.Show("No se encontraron resultados.");
                }
                Console.WriteLine($"Cantidad de registros encontrados: {asistencias.Count}");
                dataGridViewReporte.DataSource = null;
                dataGridViewReporte.DataSource = asistencias.Select(a => new
                {
                    Rut = a.Usuarios.IdUsuario,
                    Usuario = a.Usuarios.Nombre,
                    FechaHoraEntrada = a.HoraFechaEntrada,
                    FechaHoraSalida = a.HoraFechaSalida
                }).ToList();
            }

            dataGridViewReporte.Refresh();
        }

        private void btnExportarCSV_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener las fechas seleccionadas por el usuario
                DateTime fechaInicio = dateTimePickerInicio.Value;
                DateTime fechaFin = dateTimePickerFin.Value;

                fechaInicio = fechaInicio.AddMilliseconds(-fechaInicio.Millisecond);
                fechaFin = fechaFin.AddMilliseconds(-fechaFin.Millisecond);

                string reporte = comboBoxReporte.SelectedItem?.ToString(); // Obtener el tipo de reporte seleccionado
                string rutFiltro = txtRutReporte.Text.Trim();  // Obtener el Rut desde el TextBox

                if (string.IsNullOrEmpty(reporte))
                {
                    MessageBox.Show("Por favor, selecciona un tipo de reporte.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener los datos generales según el rango de fechas
                List<Asistencia> asistencias = asistenciaController.ObtenerEntradaSalida(fechaInicio, fechaFin);

                // Filtrar por Rut si se ha ingresado uno
                if (!string.IsNullOrEmpty(rutFiltro))
                {
                    asistencias = asistencias.Where(a => a.Usuarios.IdUsuario == rutFiltro).ToList();
                }

                IEnumerable<dynamic> reporteFiltrado = null;

                if (reporte == "Atrasos")
                {
                            reporteFiltrado = asistencias
                                .Where(a => a.HoraFechaEntrada.TimeOfDay > (a.Usuarios.Turnos.HoraEntradaTurno ?? TimeSpan.Zero))
                                .Select(a => new
                                {
                                    a.Usuarios.IdUsuario,
                                    a.Usuarios.Nombre,
                                    a.HoraFechaEntrada,
                                    TurnoEntrada = a.Usuarios.Turnos.HoraEntradaTurno ?? TimeSpan.Zero,
                                    MinutosAtraso = (a.HoraFechaEntrada.TimeOfDay - (a.Usuarios.Turnos.HoraEntradaTurno ?? TimeSpan.Zero)).TotalMinutes
                                });

                        }
                else if (reporte == "Salida Adelantada")
                {
                    reporteFiltrado = asistencias
                        .Where(a => a.HoraFechaSalida.HasValue &&
                                    a.HoraFechaSalida.Value.TimeOfDay < a.Usuarios.Turnos.HoraSalidaTurno)
                        .Select(a => new
                        {
                            a.Usuarios.IdUsuario,
                            a.Usuarios.Nombre,
                            a.HoraFechaSalida,
                            TurnoSalida = a.Usuarios.Turnos.HoraSalidaTurno,
                            MinutosAdelanto = (a.Usuarios.Turnos.HoraSalidaTurno - a.HoraFechaSalida?.TimeOfDay ?? TimeSpan.Zero).TotalMinutes
                        });
                }
                else if (reporte == "Inasistencias")
                {
                    // Llamada al método ObtenerInasistencias
                    var inasistencias = asistenciaController.ObtenerInasistencias(fechaInicio, fechaFin, rutFiltro);

                    // Asignar los resultados al reporteFiltrado
                    reporteFiltrado = inasistencias.Select(i => new
                    {
                        IdUsuario = i.IdUsuario,
                        Nombre = i.Nombre,
                        Fecha = i.Fecha,
                        Dia = i.Dia
                    }).ToList();
                }


                else // General
                {
                    reporteFiltrado = asistencias.Select(a => new
                    {
                        a.Usuarios.IdUsuario,
                        a.Usuarios.Nombre,
                        a.HoraFechaEntrada,
                        a.HoraFechaSalida
                    });
                }

                // Validar que haya datos para exportar
                if (reporteFiltrado == null || !reporteFiltrado.Any())
                {
                    MessageBox.Show("No se encontraron registros para exportar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Usar SaveFileDialog para permitir al usuario seleccionar la ubicación y el nombre del archivo
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                    saveFileDialog.Title = "Guardar reporte como";
                    saveFileDialog.FileName = $"reporte_{reporte.ToLower().Replace(" ", "_")}.csv";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Crear el archivo CSV en la ubicación seleccionada
                        using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                        {
                            // Escribir encabezados según el tipo de reporte
                            if (reporte == "Atrasos")
                            {
                                sw.WriteLine("Rut,Usuario,FechaHoraEntrada,TurnoEntrada,MinutosAtraso");
                                foreach (var a in reporteFiltrado)
                                {
                                    sw.WriteLine($"{a.IdUsuario},{a.Nombre},{a.HoraFechaEntrada},{a.TurnoEntrada},{a.MinutosAtraso:F2}");
                                }
                            }
                            else if (reporte == "Salida Adelantada")
                            {
                                sw.WriteLine("Rut,Usuario,FechaHoraSalida,TurnoSalida,MinutosAdelanto");
                                foreach (var a in reporteFiltrado)
                                {
                                    sw.WriteLine($"{a.IdUsuario},{a.Nombre},{a.HoraFechaSalida},{a.TurnoSalida},{a.MinutosAdelanto:F2}");
                                }
                            }
                            else if (reporte == "Inasistencias")
                            {
                                sw.WriteLine("Rut,Usuario,Fecha,Dia");
                                foreach (var a in reporteFiltrado)
                                {
                                    sw.WriteLine($"{a.IdUsuario},{a.Nombre},{a.Fecha:yyyy-MM-dd},{a.Dia}");
                                }
                            }

                            else // General
                            {
                                sw.WriteLine("Rut,Usuario,FechaHoraEntrada,FechaHoraSalida");
                                foreach (var a in reporteFiltrado)
                                {
                                    sw.WriteLine($"{a.IdUsuario},{a.Nombre},{a.HoraFechaEntrada},{a.HoraFechaSalida}");
                                }
                            }
                        }

                        MessageBox.Show("Reporte exportado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al exportar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Validar que no sea el encabezado
            {
                // Obtener el ID del usuario seleccionado
                rutActual = dataGridViewUsuarios.Rows[e.RowIndex].Cells["IdUsuario"].Value.ToString();
                Console.WriteLine($"IdUsuario seleccionado: {rutActual}");

                // Cargar los datos del usuario en los campos
                CargarDatosUsuario(rutActual);
            }
        }

        private void btnModificarUsuario_Click_1(object sender, EventArgs e)
        {
            // Limpia y depura el RUT antes de validar
            string rutNuevo = LimpiarFormatoRut(txtRutNuevo.Text);
            Console.WriteLine($"RUT ingresado: {txtRutNuevo.Text}");
            Console.WriteLine($"RUT limpio para validación: {rutNuevo}");

            if (ValidarFormulario(esCreacion: false))
            {
                try
                {
                    // Crear el objeto usuario con los datos modificados
                    var usuarioModificado = new Usuarios
                    {
                        IdUsuario = txtRutNuevo.Text.Trim(),
                        Nombre = txtNombreNuevo.Text.Trim(),
                        Correo = txtCorreoNuevo.Text.Trim(),
                        Direccion = txtDireccionNuevo.Text.Trim(),
                        Contraseña = txtContraseñaNuevo.Text.Trim(),
                        IdComuna = (int)comboBoxComuna.SelectedValue,
                        IdRol = (int)comboBoxRol.SelectedValue,
                        IdCargo = (int)comboBoxCargo.SelectedValue,
                        IdTurno = (int)comboBoxTurno.SelectedValue,
                        Activo = comboBoxEstado.SelectedValue.ToString() == "1"
                    };

                    Console.WriteLine($"Usuario modificado: {usuarioModificado.IdUsuario}, Nombre: {usuarioModificado.Nombre}");

                    // Llamar al controlador para actualizar el usuario
                    modificarUsuarioController.ModificarUsuario(usuarioModificado);

                    MessageBox.Show("Usuario modificado exitosamente.");

                    // Recargar los usuarios en el DataGridView
                    CargarUsuariosEnGrid();

                    // Limpiar el formulario tras la modificación
                    LimpiarFormularioCrearUsuario();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
                {
                    var errorMessage = $"Error al guardar cambios: {ex.Message}";
                    if (ex.InnerException != null)
                    {
                        errorMessage += $"\nInnerException: {ex.InnerException.Message}";
                        if (ex.InnerException.InnerException != null)
                        {
                            errorMessage += $"\nInnerException Nivel 2: {ex.InnerException.InnerException.Message}";
                        }
                    }

                    MessageBox.Show(errorMessage);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormularioCrearUsuario();
        }
    }


}
