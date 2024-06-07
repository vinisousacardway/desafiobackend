namespace desafiobackend.Domain.Services.Interfaces
{
    using desafiobackend.Domain.Entities;
    using System;
    using System.Collections.Generic;

    public interface ITransactionsService
    {
        IEnumerable<Transactions> GetTransactions();
        Transactions GetTransaction(int Id);
        int AddTransaction(Transactions transactions);
        int UpdateTransactions(Transactions transaction);
        int DeleteTransactions(int Id);
    }
}
