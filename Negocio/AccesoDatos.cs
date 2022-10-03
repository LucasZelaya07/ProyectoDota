using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        //Clase para acceder a la DB
        private SqlConnection conexion { get; }
        private SqlCommand comando { get; }
        private SqlDataReader lector;

        public SqlDataReader Lector
        {
            get { return lector; }
        }
        //Creo constructor
        public AccesoDatos()
        {
            conexion = new SqlConnection("server = .\\SQLEXPRESS; database = DOTA_DB; integrated security = true;");
            comando = new SqlCommand();
        }
        public void SetConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }
        public void SetearProcedimiento(string SP)
        {
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.CommandText = SP;

        }

        public void EjecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        } 

        public void EjecutarAccion()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SetParametrosInt(string numero, object valor)
        {
            int number = Convert.ToInt32(numero);
            comando.Parameters.AddWithValue(numero, valor);
        }
        public void SetParametros(string nombre, object valor)
        {
            comando.Parameters.AddWithValue(nombre, valor);
        }

        public void CerrarConexion()
        {           
                if (Lector != null)
                {
                    Lector.Close();
                }
                conexion.Close();
        }
    }
}
