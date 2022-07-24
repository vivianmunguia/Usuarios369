using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using usuarios369.Datos;
using usuarios369.Logica;

namespace usuarios369.Presentacion
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            mostrar_usuarios();
        }

        private void mostrar_usuarios()
        {
            DataTable dt;
            dusuarios funcion = new dusuarios();
            dt = funcion.mostrar_usuarios();
            datalistado.DataSource = dt;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible = true;
            panelUsuario.Dock = DockStyle.Fill;
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
            txtUsuario.Clear();
            txtPass.Clear();
        }

        private void Icono_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de imágenes";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Icono.BackgroundImage = null;
                Icono.Image = new Bitmap(dlg.FileName);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "")
            {
                if (txtPass.Text != "")
                {
                    insertar_usuario();
                    mostrar_usuarios();
                }
                else
                {
                    MessageBox.Show("Ingrese una contraseña", "Sin contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un usuario", "Sin usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void insertar_usuario()
        {
            lusuarios dt = new lusuarios();
            dusuarios funcion = new dusuarios();
            dt.Usuario = txtUsuario.Text;
            dt.Pass = txtPass.Text;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            dt.Icono = ms.GetBuffer();
            dt.Estado = "ACTIVO";

            if (funcion.insertar(dt))
            {
                MessageBox.Show("Usuario registrado", "Registro correcto");
                panelUsuario.Visible = false;
                panelUsuario.Dock = DockStyle.None;
            }
        }
    }
}
