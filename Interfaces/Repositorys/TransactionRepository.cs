using System;
using System.Collections.Generic;

public class TransactionRepository : ITransactionRepository
{
    //private readonly MyDbContext _dbContext;

    //public TransactionRepository(MyDbContext dbContext)
    //{
    //    _dbContext = dbContext;
    //}

    //public IEnumerable<Transaction> GetTransactions()
    //{
    //    return _dbContext.Transactions;
    //}

    //public Transaction GetTransaction(Guid id)
    //{
    //    return _dbContext.Transactions.Find(id);
    //}

    //public void AddTransaction(Transaction transaction)
    //{
    //    _dbContext.Transactions.Add(transaction);
    //    _dbContext.SaveChanges();
    //}

    //public void UpdateTransaction(Transaction transaction)
    //{
    //    _dbContext.Transactions.Update(transaction);
    //    _dbContext.SaveChanges();
    //}

    //public void DeleteTransaction(Guid id)
    //{
    //    var transaction = _dbContext.Transactions.Find(id);
    //    if (transaction != null)
    //    {
    //        _dbContext.Transactions.Remove(transaction);
    //        _dbContext.SaveChanges();
    //    }
    //}
}

public class MyDbContext
{
}