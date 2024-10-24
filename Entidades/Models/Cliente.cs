using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public int Cedula { get; set; }
        public int Telefono { get; set; }
        public int? Telefono2 { get; set; }
        public string Email { get; set; } = null!;
        public string? Facebook { get; set; }
        public string? Instagram { get; set; }
        public string? Tiktok { get; set; }
        public string? LinkedIn { get; set; }
        public string? Website { get; set; }
        public int Strikes { get; set; }
        public int Estado { get; set; }
        public int EstadoAzure { get; set; }
        public string? AzureURL { get; set; }
        public int IdProvincia { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; } = null!;
        public virtual Provincia IdProvinciaNavigation { get; set; } = null!;
    }
}
