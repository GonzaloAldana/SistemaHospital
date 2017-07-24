using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class Consulta:Paciente
    {
        public int IdHC { get; set; }
        public int IdP { get; set; }
        public string Peso { get; set; }
        public string Altura { get; set; }
        public string PresionArt { get; set; }
        public string Fecha { get; set; }
        public string Motivo { get; set; }
        public string Antecedentes { get; set; }
        public string Diagnostico { get; set; }
        public string Receta { get; set; }
    }
}
