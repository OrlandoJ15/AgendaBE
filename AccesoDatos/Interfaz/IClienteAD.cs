using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaz
{
    public interface IClienteAD
    {
        
        List<Cliente> recClientePA();
        Cliente recClientePAXId(int pCliente);
        bool insClientePA(Cliente pCliente);
        bool modClientePA(Cliente pCliente);
        bool delClientePA(Cliente pCliente);
        
    }
}
