using Agendamento.Application.ViewModels;

namespace Agendamento.Application.Interfaces
{
    public interface IConsultaAppService
    {
        Task<List<ConsultaViewModel>> ObterConsultasPorIdAsync(FiltroPaginacaoBasicoViewModel filtro);
        Task CadastrarConsultaAsync(CadastroConsultaViewModel consulta);
    }
}
