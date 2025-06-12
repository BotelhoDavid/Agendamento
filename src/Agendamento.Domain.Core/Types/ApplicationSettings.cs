namespace Agendamento.Domain.Core.Types
{
    public class ApplicationSettings
    {
        public int ApiVersion { get; set; }

        public string DbCommandTimeout { get; set; }

        public string Url { get; set; }
    }
}
