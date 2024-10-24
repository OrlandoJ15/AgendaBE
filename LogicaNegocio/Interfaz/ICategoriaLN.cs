
using Entidades.Models;

namespace LogicaNegocio.Interfaz
{
    public interface ICategoriaLN
    {
        List<Categoria> recCategoriaPA();
        Categoria recCategoriaPAXId(int pIdCategoria);
        bool insCategoriaPA(Categoria pIdCategoria);
        bool modCategoriaPA(Categoria pIdCategoria);
        bool delCategoriaPA(Categoria pIdCategoria);
        

    }
}
