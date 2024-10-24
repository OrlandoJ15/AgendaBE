using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Clientes = new HashSet<Cliente>();
            Subcategoria = new HashSet<Subcategoria>();
        }

        public int IdCategoria { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Subcategoria> Subcategoria { get; set; }
    }
}
