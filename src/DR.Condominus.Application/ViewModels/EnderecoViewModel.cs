using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DR.Condominus.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Prerencha o campo Logradouro")]
        [MaxLength(100, ErrorMessage ="Máximo de 100 caracreres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        public string Logradoudo { get; set; }

        [Required(ErrorMessage = "Prerencha o campo Numero")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracreres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo de 100 caracreres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Prerencha o campo {0}")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracreres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        public string Bairro { get; set; }


        [Required(ErrorMessage = "Prerencha o campo {0}")]
        [MaxLength(8, ErrorMessage = "Máximo de 8 caracreres")]
        [MinLength(8, ErrorMessage = "Mínimo de 8 caracteres")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Prerencha o campo {0}")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracreres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Prerencha o campo {0}")]
        [MaxLength(100, ErrorMessage = "Máximo de 100 caracreres")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres")]
        public string Estado { get; set; }

        [ScaffoldColumn(false)]
        public Guid ClienteId { get; set; }
    }
}
