using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdTipo { get; set; }
        public int NombreUsuario { get; set; }
        public string CodigoAcceso { get; set; }
        public string FechaCreacion { get; set; }
    }
}
