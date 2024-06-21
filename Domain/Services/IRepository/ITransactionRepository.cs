using desafiobackend.Domain.Dtos;
using desafiobackend.Domain.Entities;
using desafiobackend.Domain.Services.IGeneric;

namespace desafiobackend.Domain.Services.Repository
{
    public interface ITransactionRepository : IGeneric<Transactions>
    {
        Task<TransactionDto> MakeTransaction(Transactions model);
        Task<List<TransactionDto>> Read();
        Task<TransactionDto> Read(int id);
    }
}