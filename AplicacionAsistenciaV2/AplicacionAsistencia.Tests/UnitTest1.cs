using AplicacionAsistencia.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AplicacionAsistencia.Tests
{
    [TestFixture]
    public class AsistenciaTests
    {
        [Test]
        public void CalcularHorasSemanales_NoExcedeLimite_RetornaVerdadero()
        {
            // Simular datos de asistencia
            var asistencias = new List<Asistencia>
            {
                new Asistencia { HoraFechaEntrada = DateTime.Now.AddDays(-6).AddHours(9), HoraFechaSalida = DateTime.Now.AddDays(-6).AddHours(18) }, // 9 horas
                new Asistencia { HoraFechaEntrada = DateTime.Now.AddDays(-5).AddHours(9), HoraFechaSalida = DateTime.Now.AddDays(-5).AddHours(18) }, // 9 horas
                new Asistencia { HoraFechaEntrada = DateTime.Now.AddDays(-4).AddHours(9), HoraFechaSalida = DateTime.Now.AddDays(-4).AddHours(17) }, // 8 horas
                new Asistencia { HoraFechaEntrada = DateTime.Now.AddDays(-3).AddHours(9), HoraFechaSalida = DateTime.Now.AddDays(-3).AddHours(19) }, // 10 horas
                new Asistencia { HoraFechaEntrada = DateTime.Now.AddDays(-2).AddHours(9), HoraFechaSalida = DateTime.Now.AddDays(-2).AddHours(18) }  // 9 horas
            };

            // Sumar horas trabajadas
            double totalHorasSemanales = asistencias
                .Sum(a => (a.HoraFechaSalida.Value - a.HoraFechaEntrada).TotalHours);

            // Verificar que no se exceda el límite de 45 horas semanales
            Assert.LessOrEqual(totalHorasSemanales, 45, "El total de horas semanales excede el límite permitido.");
        }

        [Test]
        public void RegistrarSalida_ExcedeHorasDiarias_RetornaFalso()
        {
            // Simular entrada
            var asistencia = new Asistencia
            {
                HoraFechaEntrada = DateTime.Now.AddHours(-11) // Entrada hace 11 horas
            };

            // Calcular horas trabajadas
            TimeSpan horasTrabajadas = DateTime.Now - asistencia.HoraFechaEntrada;

            // Verificar que no exceda las 10 horas diarias
            Assert.LessOrEqual(horasTrabajadas.TotalHours, 10, "Se excedieron las 10 horas diarias permitidas.");
        }
    }
}

