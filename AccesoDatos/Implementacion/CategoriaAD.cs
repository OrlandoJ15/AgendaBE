
using AccesoDatos.Interfaz;
using Entidades.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos.Implementacion
{
    public class CategoriaAD : ICategoriaAD
    {

        private readonly IConfiguration _configuration;

        public CategoriaAD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Categoria> recCategoriaPA()
       {
            List<Categoria> lObjRespuesta = new List<Categoria>();
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recCategoriaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        Categoria lobjDatosCategoria = new Categoria();
                        lobjDatosCategoria.IdCategoria = Convert.ToInt32(lReader["IdCategoria"]);
                        lobjDatosCategoria.Nombre = lReader["Nombre"].ToString();
                        lObjRespuesta.Add(lobjDatosCategoria);
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

        public Categoria recCategoriaPAXId(int pIdCategoria)
        {
            Categoria lObjRespuesta = new Categoria();
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recCategoriaXIdPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@IdCategoria", pIdCategoria));
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lObjRespuesta.IdCategoria = Convert.ToInt32(lReader["IdCategoria"]);
                        lObjRespuesta.Nombre = lReader["Nombre"].ToString();

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

        public bool insCategoriaPA(Categoria pIdCategoria)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "insCategoriaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@Nombre", pIdCategoria.Nombre));
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

        public bool modCategoriaPA(Categoria pIdCategoria)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "modCategoriaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@IdCategoria", pIdCategoria.IdCategoria));
                    lCmd.Parameters.Add(new SqlParameter("@Nombre", pIdCategoria.Nombre));
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

        public bool delCategoriaPA(Categoria pIdCategoria)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "delCategoriaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@IdCategoria", pIdCategoria.IdCategoria));
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
