using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaz
{
    public interface IProvinciaAD
    {
        
        List<Provincia> recProvinciaPA();
        Provincia recProvinciaPAXId(int pIdProvincia);
        bool insProvinciaPA(Provincia pIdProvincia);
        bool modProvinciaPA(Provincia pIdProvincia);
        bool delProvinciaPA(Provincia pIdProvincia);
        
    }
}
