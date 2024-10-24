using AccesoDatos.Implementacion;
using AccesoDatos.Interfaz;
using Entidades.Models;
using LogicaNegocio.Interfaz;
using Microsoft.Extensions.Configuration;

namespace LogicaNegocio.Implementacion
{
    public class ProvinciaLN : IProvinciaLN
    {
        
        private readonly IProvinciaAD gObjProvincia_PA_AD;

        /*public CategoriaLN(string lConexionBD)
        {
            gObjCategoria_PA_AD = new CategoriaAD(lConexionBD);
        }*/
        public ProvinciaLN(IConfiguration _configuration)
        {
            gObjProvincia_PA_AD = new ProvinciaAD(_configuration);
        }
        public List<Provincia> recProvinciaPA()
        {
            List<Provincia> lObjRespuesta = new List<Provincia>();

            try
            {
                lObjRespuesta = gObjProvincia_PA_AD.recProvinciaPA();
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
                lObjRespuesta = gObjProvincia_PA_AD.recProvinciaPAXId(pIdProvincia);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }
        public bool insProvinciaPA(Provincia pProvincia)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjProvincia_PA_AD.insProvinciaPA(pProvincia);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modProvinciaPA(Provincia pProvincia)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjProvincia_PA_AD.modProvinciaPA(pProvincia);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool delProvinciaPA(Provincia pProvincia)
        {
            bool lObjRespuesta =
                false;

            try
            {
                lObjRespuesta = gObjProvincia_PA_AD.delProvinciaPA(pProvincia);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }
        
    }
}
