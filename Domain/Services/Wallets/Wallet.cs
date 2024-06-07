using System.ComponentModel.DataAnnotations;
using desafiobackend.Domain.Entities;

namespace desafiobackend.Domain.Services.Wallets
{
    public class Wallet
    {

        public Guid id { get; set; }
        public Guid Userid { get; set; }
        public string User { get; set; }
        public int balance { get; set; }

    }
}
