namespace Agendamento.Domain.Core.DTO
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string SenhaHash { get; set; }
        public string Nome { get; set; }
    }
}
