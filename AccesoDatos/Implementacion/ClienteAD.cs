
using AccesoDatos.Interfaz;
using Entidades.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos.Implementacion
{
    public class ClienteAD : IClienteAD
    {
        
        /*private readonly string gCnnBD;

        public ClienteAD(string lCnnBD)
        {
            gCnnBD = lCnnBD;
        }*/

        private readonly IConfiguration _configuration;

        public ClienteAD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cliente> recClientePA()
       {
            List<Cliente> lObjRespuesta = new List<Cliente>();
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recClientePA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        Cliente lobjDatosCliente = new Cliente();
                        lobjDatosCliente.IdCliente = Convert.ToInt32(lReader["IdCliente"]);
                        lobjDatosCliente.Nombre = lReader["Nombre"].ToString();
                        lobjDatosCliente.Cedula = Convert.ToInt32(lReader["Cedula"]);
                        lobjDatosCliente.Telefono = Convert.ToInt32(lReader["Telefono"]);
                        lobjDatosCliente.Telefono2 = Convert.ToInt32(lReader["Telefono2"]);
                        lobjDatosCliente.Email = lReader["Email"].ToString();
                        lobjDatosCliente.Facebook = lReader["Facebook"].ToString();
                        lobjDatosCliente.Instagram = lReader["Instagram"].ToString();
                        lobjDatosCliente.Tiktok = lReader["Tiktok"].ToString();
                        lobjDatosCliente.LinkedIn = lReader["LinkedIn"].ToString();
                        lobjDatosCliente.Website = lReader["Website"].ToString();
                        lobjDatosCliente.Strikes = Convert.ToInt32(lReader["Strikes"]);
                        lobjDatosCliente.Estado = Convert.ToInt32(lReader["Estado"]);
                        lobjDatosCliente.EstadoAzure = Convert.ToInt32(lReader["EstadoAzure"]);
                        lobjDatosCliente.AzureURL = lReader["AzureURL"].ToString();
                        lobjDatosCliente.IdCategoria = Convert.ToInt32(lReader["IdCategoria"]);
                        lobjDatosCliente.IdProvincia = Convert.ToInt32(lReader["IdProvincia"]);
                        lObjRespuesta.Add(lobjDatosCliente);
                    }
                    if (lCmd.Connection.State == System.Data.ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public Cliente recClientePAXId(int pIdCliente)
        {
            Cliente lObjRespuesta = new Cliente();
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recClienteXIdPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@IdCliente", pIdCliente));
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lObjRespuesta.IdCliente = Convert.ToInt32(lReader["IdCliente"]);
                        lObjRespuesta.Nombre = lReader["Nombre"].ToString();
                        lObjRespuesta.Cedula = Convert.ToInt32(lReader["Cedula"]);
                        lObjRespuesta.Telefono = Convert.ToInt32(lReader["Telefono"]);
                        lObjRespuesta.Telefono2 = Convert.ToInt32(lReader["Telefono2"]);
                        lObjRespuesta.Email = lReader["Email"].ToString();
                        lObjRespuesta.Facebook = lReader["Facebook"].ToString();
                        lObjRespuesta.Instagram = lReader["Instagram"].ToString();
                        lObjRespuesta.Tiktok = lReader["Tiktok"].ToString();
                        lObjRespuesta.LinkedIn = lReader["LinkedIn"].ToString();
                        lObjRespuesta.Website = lReader["Website"].ToString();
                        lObjRespuesta.Strikes = Convert.ToInt32(lReader["Strikes"]);
                        lObjRespuesta.Estado = Convert.ToInt32(lReader["Estado"]);
                        lObjRespuesta.EstadoAzure = Convert.ToInt32(lReader["EstadoAzure"]);
                        lObjRespuesta.AzureURL = lReader["AzureURL"].ToString();
                        lObjRespuesta.IdCategoria = Convert.ToInt32(lReader["IdCategoria"]);
                        lObjRespuesta.IdProvincia = Convert.ToInt32(lReader["IdProvincia"]);
                        

                    }
                    if (lCmd.Connection.State == System.Data.ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool insClientePA(Cliente pCliente)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "insClientePA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@nombre", pCliente.Nombre));
                    lCmd.Parameters.Add(new SqlParameter("@cedula", pCliente.Cedula));
                    lCmd.Parameters.Add(new SqlParameter("@telefono", pCliente.Telefono));
                    lCmd.Parameters.Add(new SqlParameter("@telefono2", pCliente.Telefono2));
                    lCmd.Parameters.Add(new SqlParameter("@email", pCliente.Email));
                    lCmd.Parameters.Add(new SqlParameter("@facebook", pCliente.Facebook));
                    lCmd.Parameters.Add(new SqlParameter("@instagram", pCliente.Instagram));
                    lCmd.Parameters.Add(new SqlParameter("@tiktok", pCliente.Tiktok));
                    lCmd.Parameters.Add(new SqlParameter("@linkedIn", pCliente.LinkedIn));
                    lCmd.Parameters.Add(new SqlParameter("@website", pCliente.Website));
                    lCmd.Parameters.Add(new SqlParameter("@strikes", pCliente.Strikes));
                    lCmd.Parameters.Add(new SqlParameter("@estado", pCliente.Estado));
                    lCmd.Parameters.Add(new SqlParameter("@estadoAzure", pCliente.EstadoAzure));
                    lCmd.Parameters.Add(new SqlParameter("@azureURL", pCliente.AzureURL));
                    lCmd.Parameters.Add(new SqlParameter("@provincia", pCliente.IdProvincia));
                    lCmd.Parameters.Add(new SqlParameter("@idCategoria", pCliente.IdCategoria));
                    lCmd.Connection.Open();

                    if (lCmd.ExecuteNonQuery() > 0)
                    {
                        lObjRespuesta = true;
                    }
                    if (lCmd.Connection.State == System.Data.ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modClientePA(Cliente pCliente)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "modClientePA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@IdCliente", pCliente.IdCliente));
                    lCmd.Parameters.Add(new SqlParameter("@Nombre", pCliente.Nombre));
                    lCmd.Parameters.Add(new SqlParameter("@Cedula", pCliente.Cedula));
                    lCmd.Parameters.Add(new SqlParameter("@Telefono", pCliente.Telefono));
                    lCmd.Parameters.Add(new SqlParameter("@Telefono2", pCliente.Telefono2));
                    lCmd.Parameters.Add(new SqlParameter("@Email", pCliente.Email));
                    lCmd.Parameters.Add(new SqlParameter("@Facebook", pCliente.Facebook));
                    lCmd.Parameters.Add(new SqlParameter("@Instagram", pCliente.Instagram));
                    lCmd.Parameters.Add(new SqlParameter("@Tiktok", pCliente.Tiktok));
                    lCmd.Parameters.Add(new SqlParameter("@LinkedIn", pCliente.LinkedIn));
                    lCmd.Parameters.Add(new SqlParameter("@Website", pCliente.Website));
                    lCmd.Parameters.Add(new SqlParameter("@Strikes", pCliente.Strikes));
                    lCmd.Parameters.Add(new SqlParameter("@Estado", pCliente.Estado));
                    lCmd.Parameters.Add(new SqlParameter("@EstadoAzure", pCliente.EstadoAzure));
                    lCmd.Parameters.Add(new SqlParameter("@AzureURL", pCliente.AzureURL));
                    lCmd.Parameters.Add(new SqlParameter("@IdCategoria", pCliente.IdCategoria));
                    lCmd.Parameters.Add(new SqlParameter("@Provincia", pCliente.IdProvincia));
                    lCmd.Connection.Open();

                    if (lCmd.ExecuteNonQuery() > 0)
                    {
                        lObjRespuesta = true;
                    }
                    if (lCmd.Connection.State == System.Data.ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool delClientePA(Cliente pCliente)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "delClientePA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@IdCliente", pCliente.IdCliente));
                    lCmd.Connection.Open();

                    if (lCmd.ExecuteNonQuery() > 0)
                    {
                        lObjRespuesta = true;
                    }
                    if (lCmd.Connection.State == System.Data.ConnectionState.Open)
                    {
                        lCmd.Connection.Close();
                    }
                }
            }
            catch (Exception lEx)
            {
                throw lEx;
            }
            return lObjRespuesta;
        }
    }
}
