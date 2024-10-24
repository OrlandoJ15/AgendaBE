using AccesoDatos.Implementacion;
using AccesoDatos.Interfaz;
using Entidades.Models;
using LogicaNegocio.Interfaz;
using Microsoft.Extensions.Configuration;

namespace LogicaNegocio.Implementacion
{
    public class SubCategoriaLN : ISubCategoriaLN
    {

        private readonly ISubCategoriaAD gObjSubCategoria_PA_AD;

        /*public SubCategoriaLN(string lConexionBD)
        {
            gObjCategoria_PA_AD = new SubcategoriaAD(lConexionBD);
        }*/
        public SubCategoriaLN(IConfiguration configuration)
        {
            gObjSubCategoria_PA_AD = new SubcategoriaAD(configuration);
        }
        public List<Subcategoria> recSubCategoriaPA()
        {
            List<Subcategoria> lObjRespuesta = new List<Subcategoria>();

            try
            {
                lObjRespuesta = gObjSubCategoria_PA_AD.recSubCategoriaPA();
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
                lObjRespuesta = gObjSubCategoria_PA_AD.recSubCategoriaPAXId(pIdSubCategoria);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }
        public bool insSubCategoriaPA(Subcategoria pSubcategoria)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjSubCategoria_PA_AD.insSubCategoriaPA(pSubcategoria);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool modSubCategoriaPA(Subcategoria pSubCategoria)
        {
            bool lObjRespuesta = false;

            try
            {
                lObjRespuesta = gObjSubCategoria_PA_AD.modSubCategoriaPA(pSubCategoria);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool delSubCategoriaPA(Subcategoria pSubCategoria)
        {
            bool lObjRespuesta =
                false;

            try
            {
                lObjRespuesta = gObjSubCategoria_PA_AD.delSubCategoriaPA(pSubCategoria);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

    }
}
