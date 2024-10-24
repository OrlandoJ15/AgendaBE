using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Subcategoria
    {
        public int IdSubCategoria { get; set; }
        public string? Nombre { get; set; }
        public int? IdCategoria { get; set; }

        public virtual Categoria? IdCategoriaNavigation { get; set; }
    }
}
