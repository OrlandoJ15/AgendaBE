using AccesoDatos.Implementacion;
using AccesoDatos.Interfaz;
using Entidades.Models;
using LogicaNegocio.Interfaz;
using Microsoft.Extensions.Configuration;

namespace LogicaNegocio.Implementacion
{
    public class ClienteLN : IClienteLN
    {
        

        private readonly IClienteAD gObjClienteAD;

        /*public ClienteLN(string lConexionBD)
        {
            gObjClienteAD = new ClienteAD(lConexionBD);
        }*/

        public ClienteLN(IConfiguration configuration)
        {
            gObjClienteAD = new ClienteAD(configuration);
        }
        public List<Cliente> recClientePA()
        {
            List<Cliente> lObjRespuesta = new List<Cliente>();

            try
            {
                lObjRespuesta = gObjClienteAD.recClientePA();
            }
            catch (Exception lEx)
            {

                throw lEx;
            }

            return lObjRespuesta;
        }

        public Cliente recClientePAXId(int pIdUsuario)
        {
            Cliente lObjRespuesta = new Cliente();

            try
            {
                lObjRespuesta = gObjClienteAD.recClientePAXId(pIdUsuario);
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
                lObjRespuesta = gObjClienteAD.insClientePA(pCliente);
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
                lObjRespuesta = gObjClienteAD.modClientePA(pCliente);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }

        public bool delClientePA(Cliente pCliente)
        {
            bool lObjRespuesta =
                false;

            try
            {
                lObjRespuesta = gObjClienteAD.delClientePA(pCliente);
            }
            catch (Exception lEx)
            {

                throw lEx;
            }
            return lObjRespuesta;
        }
        
    }
}
