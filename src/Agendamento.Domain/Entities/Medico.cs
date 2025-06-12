namespace Agendamento.Domain.Entities
{
    public class Medico
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string CRM { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual ICollection<Consulta> Consultas { get; set; }
    }
}
