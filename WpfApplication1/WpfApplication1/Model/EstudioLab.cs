using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class EstudioLab
    {
        public int IdEL { get; set; }
        public int IdPaciente { get; set; }
        public int IdLab { get; set; }
        public string Fecha { get; set; }
        public string Motivo { get; set; }
    }
}
