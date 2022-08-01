using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using usuarios369.Datos;
using usuarios369.Logica;

namespace usuarios369.Presentacion
{
    public partial class Usuarios : Form
    {
        int idusuario;
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

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == this.datalistado.Columns["Editar"].Index)
            {
                idusuario = Convert.ToInt32(datalistado.SelectedCells[2].Value.ToString());
                txtUsuario.Text = datalistado.SelectedCells[3].Value.ToString();
                txtPass.Text = datalistado.SelectedCells[4].Value.ToString();
                Icono.BackgroundImage = null;
                byte[] b = (Byte[])datalistado.SelectedCells[5].Value;
                System.IO.MemoryStream ms = new System.IO.MemoryStream(b);
                Icono.Image = Image.FromStream(ms);

                panelUsuario.Visible = true;
                panelUsuario.Dock = DockStyle.Fill;
                btnGuardar.Visible = false;
                btnGuardarCambios.Visible = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            panelUsuario.Visible = false;
            panelUsuario.Dock = DockStyle.None;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            editar_usuario();
            mostrar_usuarios();
        }

        private void editar_usuario()
        {
            lusuarios dt = new lusuarios();
            dusuarios funcion = new dusuarios();
            dt.Idusuario = idusuario;
            dt.Usuario = txtUsuario.Text;
            dt.Pass = txtPass.Text;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Icono.Image.Save(ms, Icono.Image.RawFormat);
            dt.Icono = ms.GetBuffer();
            dt.Estado = "ACTIVO";

            if (funcion.editar(dt))
            {
                MessageBox.Show("Usuario modificado", "Registro correcto");
                panelUsuario.Visible = false;
                panelUsuario.Dock = DockStyle.None;
            }
        }
    }
}
