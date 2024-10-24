
using AccesoDatos.Interfaz;
using Entidades.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos.Implementacion
{
    public class ProvinciaAD : IProvinciaAD
    {

        private readonly IConfiguration _configuration;

        public ProvinciaAD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Provincia> recProvinciaPA()
       {
            List<Provincia> lObjRespuesta = new List<Provincia>();
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recProvinciaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        Provincia lobjDatosProvincia = new Provincia();
                        lobjDatosProvincia.IdProvincia = Convert.ToInt32(lReader["IdProvincia"]);
                        lobjDatosProvincia.Codigo = Convert.ToInt32(lReader["Codigo"]);
                        lobjDatosProvincia.provincia = lReader["provincia"].ToString();
                        lObjRespuesta.Add(lobjDatosProvincia);
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

        public Provincia recProvinciaPAXId(int pIdProvincia)
        {
            Provincia lObjRespuesta = new Provincia();
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recProvinciaXIdPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@IdProvincia", pIdProvincia));
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lObjRespuesta.IdProvincia = Convert.ToInt32(lReader["IdProvincia"]);
                        lObjRespuesta.Codigo = Convert.ToInt32(lReader["Codigo"]);
                        lObjRespuesta.provincia = lReader["provincia"].ToString();

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

        public bool insProvinciaPA(Provincia pIdProvincia)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "insProvinciaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@Codigo", pIdProvincia.Codigo));
                    lCmd.Parameters.Add(new SqlParameter("@Provincia", pIdProvincia.provincia));
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

        public bool modProvinciaPA(Provincia pIdProvincia)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "modProvinciaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@IdProvincia", pIdProvincia.IdProvincia));
                    lCmd.Parameters.Add(new SqlParameter("@codigo", pIdProvincia.Codigo));
                    lCmd.Parameters.Add(new SqlParameter("@provincia", pIdProvincia.provincia));
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

        public bool delProvinciaPA(Provincia pIdProvincia)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "delProvinciaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@IdProvincia", pIdProvincia.IdProvincia));
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
