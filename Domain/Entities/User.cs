using desafiobackend.Controllers;
using System.ComponentModel.DataAnnotations.Schema;

namespace desafiobackend.Domain.Entities
{
    public enum UserType
    {
        regular,
        shopkeeper
    }

    public class User // Deverá estar em Domain >  Entities.
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("Full_Name")]
        public string FullName { get; set; }

        [Column("Document")]
        public string Document { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Password")]
        public string Password { get; set; }
    }
}
