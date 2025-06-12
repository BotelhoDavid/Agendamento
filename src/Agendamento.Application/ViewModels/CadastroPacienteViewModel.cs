using System.ComponentModel.DataAnnotations;

namespace Agendamento.Application.ViewModels
{
    public class CadastroPacienteViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"\d{11}", ErrorMessage = "CPF deve conter 11 dígitos numéricos.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
