namespace Agendamento.Infra.CrossCutting.Chain.Providers
{
    public abstract class ChainBase
    {
        public ChainBase Next { get; set; }
    }
}
