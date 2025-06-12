using Agendamento.Application.ViewModels;
using Agendamento.Domain.Entities;

namespace Agendamento.Application.Interfaces
{
    public interface IPacienteAppService
    {
        public IEnumerable<Paciente> ObterPacientes();

        Task CadastrarPaciente(CadastroPacienteViewModel paciente);
    }
}
