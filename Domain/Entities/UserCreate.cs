using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace desafiobackend.Domain.Entities
{
    public class UserCreate
    {
        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Email { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Password { get; set; }
        [Required]
        [MinLength(11)]
        [RegularExpression(@"\d{11}")]
        public string CPF { get; set; }
        [DefaultValue(0)]
        public UserType Type { get; set; }
    }
}

