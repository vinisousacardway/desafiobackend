using desafiobackend.Controllers;
using System.ComponentModel.DataAnnotations.Schema;

namespace desafiobackend.Domain.Entities
{
    public class User
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("Full_Name")]
        public string FullName { get; set; }

        [Column("CPF_CNPJ")]
        public string CPF_CNPJ { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Password")]
        public string Password { get; set; }
    }
}
