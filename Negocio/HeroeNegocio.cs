using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class HeroeNegocio
    {
        //Donde creo los metodos de acceso a DB para los pokemones
        public List<Heroes> listaHeroe()
        {
            List<Heroes> lista = new List<Heroes>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                
                conexion.ConnectionString = "server = .\\SQLEXPRESS; database = DOTA_DB; integrated security = true;";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, H.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, H.IdTipo, H.IdDebilidad, H.Id From HEROES H, ELEMENTOS E, ELEMENTOS D where E.Id = H.IdTipo AND D.Id = H.IdDebilidad AND H.Activo = 1";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    
                    Heroes aux = new Heroes();
                    aux.Id = (int)lector["Id"];
                    aux.Numero = lector.GetInt32(0);
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    if (!(lector.IsDBNull(lector.GetOrdinal("UrlImagen"))))
                        aux.UrlImagen = (string)lector["UrlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)lector["Tipo"];
                    aux.Ventaja = new Elemento();
                    aux.Ventaja.Id = (int)lector["IdVentaja"];
                    aux.Ventaja.Descripcion = (string)lector["Ventaja"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];
                    lista.Add(aux);
                }
                return lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Cierro la conexión a DB
                conexion.Close();
            }

        }
        public List<Heroes> listarConSP()
        {
            List<Heroes> lista = new List<Heroes>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                
                datos.SetearProcedimiento("storedListar");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Heroes aux = new Heroes();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("UrlImagen"))))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];
                    //aux.Ventaja = new Elemento();
                    //aux.Ventaja.Id = (int)datos.Lector["IdVentaja"];
                    //aux.Ventaja.Descripcion = (string)datos.Lector["Ventaja"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Agregar(Heroes nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, IdVentaja, UrlImagen) values(@Numero, @Nombre, @Descripcion, '1', @IdTipo, @IdDebilidad, @IdVentaja, @UrlImagen)");
                datos.SetParametros("@Numero", nuevo.Numero);
                datos.SetParametros("@Nombre", nuevo.Nombre);
                datos.SetParametros("@Descripcion", nuevo.Descripcion);
                datos.SetParametros("@IdTipo", nuevo.Tipo.Id);
                datos.SetParametros("@IdDebilidad", nuevo.Debilidad.Id);
                datos.SetParametros("@IdVentaja", nuevo.Ventaja.Id);
                datos.SetParametros("@UrlImagen", nuevo.UrlImagen);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void AgregarconSP(Heroes nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearProcedimiento("storedAltaHeroes");
                datos.SetParametros("@Numero", nuevo.Numero);
                datos.SetParametros("@Nombre", nuevo.Nombre);
                datos.SetParametros("@Descripcion", nuevo.Descripcion);
                datos.SetParametros("@UrlImagen", nuevo.UrlImagen);
                datos.SetParametros("@IdTipo", nuevo.Tipo.Id);
                datos.SetParametros("@IdDebilidad", nuevo.Debilidad.Id);
                datos.SetParametros("@IdVentaja", nuevo.Ventaja.Id);
                
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void modificar(Heroes modificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.SetConsulta("update Heroes set Numero = @Numero, Nombre = @Nombre, Descripcion = @Descripcion, UrlImagen = @Url, IdTipo = @IdTipo, IdDebilidad = @IdDebilidad, IdVentaja = @IdVentaja where Id = @Id");
                datos.SetParametros("@Numero", modificar.Numero);
                datos.SetParametros("@Nombre", modificar.Nombre);
                datos.SetParametros("@Descripcion", modificar.Descripcion);
                datos.SetParametros("@UrlImagen", modificar.UrlImagen);
                datos.SetParametros("@IdTipo", modificar.Tipo.Id);
                datos.SetParametros("@IdDebilidad", modificar.Debilidad.Id);
                datos.SetParametros("IdVentaja", modificar.Ventaja.Id);
                datos.SetParametros("@Id", modificar.Id);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Heroes> Filtrar(string campo, string criterio, string filtro)
        {
            List<Heroes> lista = new List<Heroes>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select Numero, Nombre, H.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad, D.Descripcion Ventaja, H.IdTipo, H.IdDebilidad, H.IdVentaja, H.Id From HEROES H, ELEMENTOS E, ELEMENTOS D where E.Id = H.IdTipo AND D.Id = H.IdDebilidad AND H.Activo = 1 AND ";
                if (campo == "Numero")
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Numero > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "Numero < " + filtro;
                            break;
                        default:
                            consulta += "Numero = " + filtro;
                            break;
                    }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "Nombre like '%" + filtro + "%' ";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "H.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "H.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "H.Descripcion like '%" + filtro + "%' ";
                            break;
                    }
                }
                datos.SetConsulta(consulta);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Heroes aux = new Heroes();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = datos.Lector.GetInt32(0);
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector.IsDBNull(datos.Lector.GetOrdinal("UrlImagen"))))
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];
                    aux.Tipo = new Elemento();
                    aux.Tipo.Id = (int)datos.Lector["IdTipo"];
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];
                    aux.Ventaja = new Elemento();
                    aux.Ventaja.Id = (int)datos.Lector["IdVentaja"];
                    aux.Ventaja.Descripcion = (string)datos.Lector["Ventaja"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Eliminar(int Id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetConsulta("delete from Heroes where Id = @Id");
                datos.SetParametros("Id", Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void EliminarLogico(int Id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.SetConsulta("update from Heroes set Activo = 0 where Id = @Id");
                datos.SetParametros("Id", Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<Heroes> listarHeroe()
        {
            List<Heroes> lista = new List<Heroes>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetConsulta("Select Nombre From Heroes");
                datos.EjecutarLectura();

                while (datos.Lector.Read())
                {
                    Heroes aux = new Heroes();
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    lista.Add(aux);

                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
