using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class Paciente: Persona
    {
        public int IdPaciente { get; set; }
        public string Ocupacion { get; set; }
    }
}
