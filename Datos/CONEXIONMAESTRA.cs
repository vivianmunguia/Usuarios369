﻿using System.Data;
using System.Data.SqlClient;

namespace usuarios369.Datos
{
    internal static class CONEXIONMAESTRA
    {
        public static SqlConnection conexion = new SqlConnection
            (@"Data source=LAPTOP-NLHO6AEK\SQLEXPRESS; Initial Catalog=USUARIOSDB; Integrated Security=true");

        public static void abrir()
        {
            if (conexion.State == ConnectionState.Closed)
            {
                conexion.Open();
            }
        }

        public static void cerrar()
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
            }
        }
    }
}
