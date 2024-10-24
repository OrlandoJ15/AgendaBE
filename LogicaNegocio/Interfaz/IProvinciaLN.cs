
using Entidades.Models;

namespace LogicaNegocio.Interfaz
{
    public interface IProvinciaLN
    {
        List<Provincia> recProvinciaPA();
        Provincia recProvinciaPAXId(int pIdProvincia);
        bool insProvinciaPA(Provincia pIdProvincia);
        bool modProvinciaPA(Provincia pIdProvincia);
        bool delProvinciaPA(Provincia pIdProvincia);
        

    }
}
