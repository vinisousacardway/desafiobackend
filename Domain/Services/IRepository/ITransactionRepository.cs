using desafiobackend.Domain.Dtos;
using desafiobackend.Domain.Entities;
using desafiobackend.Domain.Services.Interfaces;

namespace desafiobackend.Domain.Services.Repository
{
    public interface ITransactionRepository : IGeneric<Transactions>
    {
        Task<TransactionDTO> MakeTransaction(Transactions model);
        Task<List<TransactionDTO>> Read();
        Task<TransactionDTO> Read(int id);
    }
}