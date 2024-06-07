using Microsoft.AspNetCore.Mvc.RazorPages;

namespace desafiobackend.Domain.Dtos
{
    public class TransactionUpdateRequestDto
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int Amount { get; set; }
    }
}
