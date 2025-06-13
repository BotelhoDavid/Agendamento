using Agendamento.Application.ViewModels;

namespace Agendamento.Application.Interfaces
{
    public interface IMedicoAppService
    {
        Task<List<string>> ObterEspecialidadesAsync();
        Task<List<MedicoViewModel>> ObterMedicoPorEspecialidadeAsync(string especialidade);
    }
}
