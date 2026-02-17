using AplicacionAsistencia.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionAsistencia.Controller
{
    public class CrearUsuarioController
    {
        AplicacionAsistenciaEntities conexion = new AplicacionAsistenciaEntities();
        public List<object> ObtenerRegionesConIds()
        {

            return conexion.Regiones
                     .Select(r => new { Id = r.IdRegion, Nombre = r.NombreRegion })
                     .ToList<object>();

        }

        public List<object> ObtenerCiudadesPorRegionId(int idRegion)
        {

            return conexion.Ciudades
                     .Where(c => c.IdRegion == idRegion)
                     .Select(c => new { Id = c.IdCiudad, Nombre = c.NombreCiudad })
                     .ToList<object>();

        }

        public List<object> ObtenerComunasPorCiudadId(int idCiudad)
        {

            return conexion.Comunas
                     .Where(c => c.IdCiudad == idCiudad)
                     .Select(c => new { Id = c.IdComuna, Nombre = c.NombreComuna })
                     .ToList<object>();

        }

        public List<object> ObtenerRolesConIds()
        {

            return conexion.Roles
                     .Select(r => new { Id = r.IdRol, Nombre = r.NombreRol })
                     .ToList<object>();

        }

        public List<object> ObtenerCargosConIds()
        {

            return conexion.Cargo
                     .Select(c => new { Id = c.IdCargo, Nombre = c.NombreCargo })
                     .ToList<object>();
        }

        public List<object> ObtenerTurnosConIds()
        {

            return conexion.Turnos
                     .Select(t => new { Id = t.IdTurno, Nombre = t.NombreTurno })
                     .ToList<object>();

        }

        public void CrearUsuario(Usuarios nuevoUsuario)
        {

            conexion.Usuarios.Add(nuevoUsuario);
            conexion.SaveChanges();
       
        }


    }
}
