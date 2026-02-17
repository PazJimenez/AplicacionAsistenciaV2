using AplicacionAsistencia.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacionAsistencia.View
{
    public partial class Login : Form
    {
        public AplicacionAsistenciaEntities conexion;
        public Login()
        {
            InitializeComponent();
            conexion = new AplicacionAsistenciaEntities();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string rut = txtRut.Text;
            string contrasena = txtContrasena.Text;

            if (!string.IsNullOrWhiteSpace(rut) && !string.IsNullOrWhiteSpace(contrasena))
            {
                // Buscar el usuario por el Rut (IdUsuario)
                var usuario = conexion.Usuarios.FirstOrDefault(u => u.IdUsuario == rut);

                if (usuario != null)
                {
                    // Validar que la contraseña coincida
                    if (usuario.Contraseña == contrasena)
                    {
                        // Si el login es exitoso, ocultar el formulario de login
                        this.Hide();

                        // Pasar el RUT al nuevo formulario Form1
                        Form1 asistenciaForm = new Form1(rut); // Pasamos el rut al constructor de Form1
                        asistenciaForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta.");
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no existe.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un RUT y contraseña válidos.");
            }
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            // Código relacionado con cambios en la contraseña
        }

    }
}


