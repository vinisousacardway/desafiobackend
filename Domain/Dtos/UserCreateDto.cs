using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;
using desafiobackend.Domain.Entities;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace desafiobackend.Domain.Dtos
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(10, ErrorMessage = "O campo {0} deve ter mais de 10 caracteres.")]
        [MaxLength(1000)]
        public string Id { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(10, ErrorMessage = "O campo {0} deve ter mais de 10 caracteres.")]
        [MaxLength(1000)]
        public string FullName { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress]
        [MinLength(10, ErrorMessage = "O campo {0} deve ter mais de 10 caracteres.")]
        [MaxLength(1000)]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(10, ErrorMessage = "O campo {0} deve ter mais de 10 caracteres.")]
        [MaxLength(1000)]
        public string Password { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(11, ErrorMessage = "O campo {0} deve ter mais de 10 caracteres.")]
        public string Document { get; set; }
        [DefaultValue(0)]
        public UserType Type { get; set; }
    }
}
