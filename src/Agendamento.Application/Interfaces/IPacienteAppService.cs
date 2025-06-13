using Agendamento.Application.ViewModels;

namespace Agendamento.Application.Interfaces
{
    public interface IPacienteAppService
    {
        Task<List<PacienteViewModel>> ObterPacientesAsync();

        Task CadastrarPacienteAsync(CadastroPacienteViewModel paciente);
    }
}
