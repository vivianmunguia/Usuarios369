using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
                CONEXIONMAESTRA.abrir();
                cmd = new SqlCommand("insertar_usuario", CONEXIONMAESTRA.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", dt.Usuario);
                cmd.Parameters.AddWithValue("@Pass", dt.Pass);
                cmd.Parameters.AddWithValue("@Icono", dt.Icono);
                cmd.Parameters.AddWithValue("@Estado", dt.Estado);

                if (cmd.ExecuteNonQuery() != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                CONEXIONMAESTRA.cerrar();
            }
        }
    }
}
