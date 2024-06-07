using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using desafiobackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafiobackend.Domain.Dtos
{
    public class RetailesCreateDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(10, ErrorMessage = "O campo {0} deve ter mais de 10 caracteres.")]
        [MaxLength(1000)]
        public int Owner { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(10, ErrorMessage = "O campo {0} deve ter mais de 10 caracteres.")]
        [DefaultValue(0)]
        public StatusTransaction Status { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(10, ErrorMessage = "O campo {0} deve ter mais de 10 caracteres.")]
        [DefaultValue(0)]
        public decimal Value { get; set; }
    }
}