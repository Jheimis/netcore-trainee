using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Trainee.Application.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Ativo é obrigatório")]
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
    }
}
