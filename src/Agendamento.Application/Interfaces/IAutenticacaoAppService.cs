namespace Agendamento.Application.Interfaces
{
    public interface IAutenticacaoAppService
    {
        Task<string> AutenticarAsync(string email, string senha);
    }
}
