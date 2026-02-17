using AplicacionAsistencia.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionAsistencia.Controller
{
    public class ModificarUsuarioController
    {
        AplicacionAsistenciaEntities conexion = new AplicacionAsistenciaEntities();

        public void ModificarUsuario(Usuarios usuarioModificado)
        {

                try
                {
                    // Buscar el usuario existente en la base de datos por su IdUsuario
                    var usuarioExistente = conexion.Usuarios.FirstOrDefault(u => u.IdUsuario == usuarioModificado.IdUsuario);
                Console.WriteLine($"usuarioExistente controlador: {usuarioExistente}");


                    if (usuarioExistente != null)
                    {
                        // Actualizar los campos con los nuevos datos
                        usuarioExistente.Nombre = usuarioModificado.Nombre;
                        usuarioExistente.Correo = usuarioModificado.Correo;
                        usuarioExistente.Direccion = usuarioModificado.Direccion;
                        usuarioExistente.Contraseña = usuarioModificado.Contraseña;
                        usuarioExistente.IdComuna = usuarioModificado.IdComuna;
                        usuarioExistente.IdRol = usuarioModificado.IdRol;
                        usuarioExistente.IdCargo = usuarioModificado.IdCargo;
                        usuarioExistente.IdTurno = usuarioModificado.IdTurno;
                        usuarioExistente.Activo = usuarioModificado.Activo;

                        // Guardar los cambios en la base de datos
                        conexion.SaveChanges();


                    }
                    else
                    {
                        MessageBox.Show("No se encontró el usuario para modificar.");
                    }
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
}
