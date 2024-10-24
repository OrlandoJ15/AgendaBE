using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaz
{
    public interface ISubCategoriaAD
    {

        List<Subcategoria> recSubCategoriaPA();
        Subcategoria recSubCategoriaPAXId(int pIdSubCategoria);
        bool insSubCategoriaPA(Subcategoria pIdSubCategoria);
        bool modSubCategoriaPA(Subcategoria pIdSubCategoria);
        bool delSubCategoriaPA(Subcategoria pIdSubCategoria);

    }
}
