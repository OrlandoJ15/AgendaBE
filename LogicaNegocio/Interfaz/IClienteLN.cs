
using Entidades.Models;

namespace LogicaNegocio.Interfaz
{
    public interface IClienteLN
    {
        
        List<Cliente> recClientePA();
        Cliente recClientePAXId(int pCliente);
        bool insClientePA(Cliente pCliente);
        bool modClientePA(Cliente pCliente);
        bool delClientePA(Cliente pCliente);
        

    }
}
