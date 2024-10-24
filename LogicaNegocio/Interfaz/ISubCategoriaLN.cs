
using Entidades.Models;

namespace LogicaNegocio.Interfaz
{
    public interface ISubCategoriaLN
    {
        List<Subcategoria> recSubCategoriaPA();
        Subcategoria recSubCategoriaPAXId(int pIdSubCategoria);
        bool insSubCategoriaPA(Subcategoria pIdSubCategoria);
        bool modSubCategoriaPA(Subcategoria pIdSubCategoria);
        bool delSubCategoriaPA(Subcategoria pIdSubCategoria);


    }
}
