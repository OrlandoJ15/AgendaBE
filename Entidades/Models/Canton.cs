using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Canton
    {
        public int Id { get; set; }
        public int CodigoProvincia { get; set; }
        public int Codigo { get; set; }
        public string? Canton1 { get; set; }
    }
}
