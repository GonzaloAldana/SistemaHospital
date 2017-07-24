using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    class Cita:Paciente
    {
        public int IdCita { get; set; }
       // public int IdPaciente { get; set; }
        public string FechaHora { get; set; }
    }
}
