using System.ComponentModel.DataAnnotations;

namespace desafiobackend.Domain.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime ExecutionDate { get; set; }
        [Required]
        public int User { get; set; }
        [Required]
        public long Amount { get; set; }
        public int Balance { get; set; }
        [Required]
        public decimal Value { get; set; }
    }
}
