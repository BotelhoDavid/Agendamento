namespace Agendamento.Domain.Entities
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
