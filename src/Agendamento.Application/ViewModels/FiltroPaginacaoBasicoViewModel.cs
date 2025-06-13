namespace Agendamento.Application.ViewModels
{
    public class FiltroPaginacaoBasicoViewModel
    {
        private const int PaginaPadrao = 0;
        private const int QuantidadeItensPadrao = 10;

        public FiltroPaginacaoBasicoViewModel()
        {
            Pagina = PaginaPadrao;
            ItensPorPagina = QuantidadeItensPadrao;
        }

        public FiltroPaginacaoBasicoViewModel(Guid pacienteId)
        {
            Id = pacienteId;
            Pagina = PaginaPadrao;
            ItensPorPagina = QuantidadeItensPadrao;
        }

        public Guid? Id { get; set; }
        public int Pagina { get; set; }
        public int ItensPorPagina { get; set; }
        public DateTime? Data { get; set; }
        public TimeSpan? Horario { get; set; }
    }
}
