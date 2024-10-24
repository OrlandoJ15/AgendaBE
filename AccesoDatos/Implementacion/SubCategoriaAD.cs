
using AccesoDatos.Interfaz;
using Entidades.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AccesoDatos.Implementacion
{
    public class SubcategoriaAD : ISubCategoriaAD
    {

        /*private readonly string gCnnBD;

        public SubcategoriaAD(string lCnnBD)
        {
            gCnnBD = lCnnBD;
        }*/

        private readonly IConfiguration _configuration;

        public SubcategoriaAD(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Subcategoria> recSubCategoriaPA()
        {
            List<Subcategoria> lObjRespuesta = new List<Subcategoria>();
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recSubCategoriaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        Subcategoria lobjDatosSubCategoria = new Subcategoria();
                        lobjDatosSubCategoria.IdSubCategoria = Convert.ToInt32(lReader["IdSubCategoria"]);
                        lobjDatosSubCategoria.Nombre = lReader["Nombre"].ToString();
                        lObjRespuesta.Add(lobjDatosSubCategoria);
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

        public Subcategoria recSubCategoriaPAXId(int pIdSubCategoria)
        {
            Subcategoria lObjRespuesta = new Subcategoria();
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "recSubCategoriaXIdPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@IdSubCategoria", pIdSubCategoria));
                    lCmd.Connection.Open();
                    var lReader = lCmd.ExecuteReader();
                    while (lReader.Read())
                    {
                        lObjRespuesta.IdSubCategoria = Convert.ToInt32(lReader["IdSubCategoria"]);
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

        public bool insSubCategoriaPA(Subcategoria pIdSubCategoria)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "insSubCategoriaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@Nombre", pIdSubCategoria.Nombre));
                    lCmd.Parameters.Add(new SqlParameter("@idCategoria", pIdSubCategoria.IdCategoria));
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

        public bool modSubCategoriaPA(Subcategoria pIdSubCategoria)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "modSubCategoriaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@IdSubCategoria", pIdSubCategoria.IdSubCategoria));
                    lCmd.Parameters.Add(new SqlParameter("@Nombre", pIdSubCategoria.Nombre));
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

        public bool delSubCategoriaPA(Subcategoria pIdSubCategoria)
        {
            bool lObjRespuesta = false;
            try
            {
                using (AgendaContext lobjCnn = new AgendaContext(_configuration))
                {
                    var lCmd = lobjCnn.Database.GetDbConnection().CreateCommand();
                    lCmd.CommandText = "delSubCategoriaPA";
                    lCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    lCmd.Parameters.Add(new SqlParameter("@IdSubCategoria", pIdSubCategoria.IdSubCategoria));
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
