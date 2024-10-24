using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaz
{
    public interface ICategoriaAD
    {
        
        List<Categoria> recCategoriaPA();
        Categoria recCategoriaPAXId(int pIdCategoria);
        bool insCategoriaPA(Categoria pIdCategoria);
        bool modCategoriaPA(Categoria pIdCategoria);
        bool delCategoriaPA(Categoria pIdCategoria);
        
    }
}
