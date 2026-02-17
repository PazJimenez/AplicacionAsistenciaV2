using AplicacionAsistencia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AplicacionAsistencia.Controller
{
    public class AsistenciaController
    {
        AplicacionAsistenciaEntities conexion = new AplicacionAsistenciaEntities();

        public void MarcarEntrada(Asistencia nuevaMarca)
        {
            conexion.Asistencia.Add(nuevaMarca);
            conexion.SaveChanges();
        }

        public void MarcarSalida(Asistencia marcaSalida)
        {
            // Buscar el registro existente en la base de datos
            var asistenciaExistente = conexion.Asistencia.Find(marcaSalida.IdAsistencia);

            if (asistenciaExistente != null)
            {
                // Actualizar los datos que necesitas modificar
                asistenciaExistente.HoraFechaSalida = marcaSalida.HoraFechaSalida;

                // Guardar los cambios
                conexion.SaveChanges();
            }
            else
            {
                throw new Exception("No se encontró el registro de asistencia para actualizar la salida.");
            }
        }
        public List<Asistencia> ObtenerEntradaSalida(DateTime fechaInicio, DateTime fechaFin, string rutFiltro = null)
        {
            if (conexion.Database.Connection.State != System.Data.ConnectionState.Open)
            {
                conexion.Database.Connection.Open();
            }

            var query = conexion.Asistencia
                                .Include(a => a.Usuarios)
                                .Include(a => a.Usuarios.Turnos)
                                .Where(a => DbFunctions.TruncateTime(a.HoraFechaEntrada) >= fechaInicio.Date &&
                                            DbFunctions.TruncateTime(a.HoraFechaEntrada) <= fechaFin.Date);

            /*if (!string.IsNullOrEmpty(rutFiltro))
            {
                query = query.Where(a => a.Usuarios.IdUsuario == rutFiltro);
            }*/

            var resultados = query.ToList();

            // Validar y mostrar la cantidad de registros encontrados
            Console.WriteLine($"Cantidad de registros encontrados controlador: {resultados.Count}");

            return resultados;
        }

        public List<dynamic> ObtenerInasistencias(DateTime fechaInicio, DateTime fechaFin, string rutFiltro)
        {
            using (var db = new AplicacionAsistenciaEntities())
            {
                // Obtener las fechas dentro del rango
                var fechasRango = Enumerable.Range(0, (fechaFin - fechaInicio).Days + 1)
                                            .Select(d => fechaInicio.AddDays(d))
                                            .ToList();

                // Filtrar usuarios por RUT si es necesario
                var usuarios = db.Usuarios.AsQueryable();
                if (!string.IsNullOrEmpty(rutFiltro))
                {
                    usuarios = usuarios.Where(u => u.IdUsuario == rutFiltro);
                }
                var listaUsuarios = usuarios.ToList(); // Materializar aquí para evitar problemas con LINQ

                // Obtener las fechas de asistencia registradas en el rango
                var asistencias = db.Asistencia
                                    .Where(a => a.HoraFechaEntrada >= fechaInicio && a.HoraFechaEntrada <= fechaFin)
                                    .Select(a => new
                                    {
                                        a.Usuarios.IdUsuario,
                                        a.Usuarios.Nombre,
                                        Fecha = DbFunctions.TruncateTime(a.HoraFechaEntrada) // Esto elimina la parte de la hora
                                    })
                                    .Distinct()
                                    .ToList(); // Materializar aquí para evitar problemas con LINQ

                // Identificar las inasistencias
                // Paso 1: Carga los usuarios y sus asistencias desde la base de datos.
                var usuariosConAsistencias = listaUsuarios.Select(u => new
                {
                    Usuario = u,
                    Asistencias = asistencias.Where(a => a.IdUsuario == u.IdUsuario).ToList()
                }).ToList();

                // Paso 2: Procesa el rango de fechas y genera las inasistencias.
                var inasistencias = (from u in usuariosConAsistencias
                                     from fecha in fechasRango
                                     where !u.Asistencias.Any(a => a.Fecha == fecha)
                                     select new
                                     {
                                         u.Usuario.IdUsuario,
                                         u.Usuario.Nombre,
                                         Fecha = fecha,
                                         Dia = fecha.DayOfWeek.ToString()
                                     }).ToList()
                                     .Select(i => (dynamic)new
                                     {
                                         i.IdUsuario,
                                         i.Nombre,
                                         i.Fecha,
                                         i.Dia
                                     })
                                     .ToList();

                return inasistencias;
            }
        }




        public bool EsDiaLaboral(DateTime fecha)
        {
            // Excluir domingos
            if (fecha.DayOfWeek == DayOfWeek.Sunday)
                return false;

            // Agregar lógica para feriados si es necesario
            // Ejemplo: List<DateTime> feriados = ObtenerFeriados();
            // if (feriados.Contains(fecha.Date)) return false;

            return true;
        }



    }
}
