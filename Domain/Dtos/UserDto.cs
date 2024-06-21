using System.ComponentModel.DataAnnotations.Schema;

namespace desafiobackend.Domain.Dtos
{
    public class UserDto
 
        {
        public string FullName { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public UserType Type { get; set; }
    }
}

