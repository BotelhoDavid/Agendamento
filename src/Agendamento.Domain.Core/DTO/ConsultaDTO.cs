using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Domain.Core.DTO
{
    public class ConsultaDTO
    {
        [Column(TypeName = "date")] 
        public DateTime Data { get; set; }

        [Column(TypeName = "time")] 
        public TimeSpan Horario { get; set; }
        public string Especialidade { get; set; } = default!;

        //medico
        public Guid MedicoId { get; set; }
        public string MedicoNome { get; set; } = default!;
        public string MedicoEspecialidade { get; set; } = default!;
        public string CRM { get; set; } = default!;


        //Paciente
        public Guid PacienteId { get; set; }
        public string PacienteNome { get; set; } = default!;
        public string CPF { get; set; } = default!;
        public DateTime DataNascimento { get; set; }
    }
}
