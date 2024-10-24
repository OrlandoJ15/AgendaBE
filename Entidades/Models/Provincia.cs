using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int IdProvincia { get; set; }
        public int? Codigo { get; set; }
        public string? provincia { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
