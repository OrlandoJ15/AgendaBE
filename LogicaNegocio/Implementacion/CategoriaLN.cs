using AccesoDatos.Implementacion;
using AccesoDatos.Interfaz;
using Entidades.Models;
using LogicaNegocio.Interfaz;
using Microsoft.Extensions.Configuration;

namespace LogicaNegocio.Implementacion
{
    public class CategoriaLN : ICategoriaLN
    {
        
        private readonly ICategoriaAD gObjCategoria_PA_AD;

        /*public CategoriaLN(string lConexionBD)
        {
            gObjCategoria_PA_AD = new CategoriaAD(lConexionBD);
        }*/
        public CategoriaLN(IConfiguration _configuration)
        {
            gObjCategoria_PA_AD = new CategoriaAD(_configuration);
        }
        public List<Categoria> recCategoriaPA()
        {
            List<Categoria> lObjRespuesta = new List<Categoria>();

            try
            {
                lObjRespuesta = gObjCategoria_PA_AD.recCategoriaPA();
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
                lObjRespuesta = gObjCategoria_PA_AD.recCategoriaPAXId(pIdCategoria);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }
        public bool insCategoriaPA(Categoria pCategoria)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjCategoria_PA_AD.insCategoriaPA(pCategoria);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modCategoriaPA(Categoria pCategoria)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjCategoria_PA_AD.modCategoriaPA(pCategoria);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool delCategoriaPA(Categoria pCategoria)
        {
            bool lObjRespuesta =
                false;

            try
            {
                lObjRespuesta = gObjCategoria_PA_AD.delCategoriaPA(pCategoria);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }
        
    }
}
