namespace Agendamento.Domain.Core.Settings
{
    public class TokenConfigurationsSettings
    {
        public string Secret { get; set; }

        public double ExpiresIn { get; set; }
    }
}
