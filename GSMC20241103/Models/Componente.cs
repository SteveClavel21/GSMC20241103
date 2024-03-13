using System;
using System.Collections.Generic;

namespace GSMC20241103.Models
{
    public partial class Componente
    {
        public int Id { get; set; }
        public int? ComputadoraId { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Tipo { get; set; }
        public string? Marca { get; set; }
        public decimal? Precio { get; set; }

        public virtual Computadora? Computadora { get; set; }
    }
}
