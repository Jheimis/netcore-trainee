using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Trainee.Application.ViewModels
{
    public class ProdutoViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Valor é obrigatório")]
        [DisplayName("Valor")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Ativo é obrigatório")]
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
    }
}
