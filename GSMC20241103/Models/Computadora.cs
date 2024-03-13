using System;
using System.Collections.Generic;

namespace GSMC20241103.Models
{
    public partial class Computadora
    {
        public Computadora()
        {
            Componente = new List<Componente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public decimal? Precio { get; set; }

        public virtual IList<Componente> Componente { get; set; }
    }
}
