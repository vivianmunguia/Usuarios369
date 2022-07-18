using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using usuarios369.Logica;

namespace usuarios369.Datos
{
    class dusuarios
    {
        private SqlCommand cmd = new SqlCommand();
        private int idusuario;
        public bool insertar(lusuarios dt)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
