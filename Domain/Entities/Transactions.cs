namespace desafiobackend.Domain.Entities
{
    public class Transactions
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int Retailers  { get; set; }
        public long Amount { get; set; }
        public StatusTransaction Status { get; set; }
     
    }
}
