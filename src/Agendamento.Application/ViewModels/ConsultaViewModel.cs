using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Application.ViewModels
{
    public class ConsultaViewModel
    {
        public Guid Id { get; set; }
        public PacienteViewModel Paciente { get; set; }
        public MedicoViewModel Medico { get; set; }
        public string Especialidade { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Horario { get; set; }

    }
}
