using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendamento.Domain.Core.DTO
{
    public class MedicoDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = default!;
        public string CRM { get; set; } = default!;
    }
}
