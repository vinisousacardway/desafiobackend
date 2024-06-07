using desafiobackend.Domain.Entities;
using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace desafiobackend.Domain.Services.Interfaces
{
    public class TransactionsService : ITransactionsService
    {
        private readonly List<Transactions> _transactions = new List<Transactions>();
        private Transactions transactions;

        public Transactions GetTransaction(int Id)
        {
            return _transactions.FirstOrDefault(t => t.Id == Id);
        }

        public IEnumerable<Transactions> GetTransactions()
        {
            return _transactions;
        }

        public int AddTransaction(Transactions transactions)
        {
            transactions.Id = _transactions.Count + 1;
            _transactions.Add(transactions);
            return 1;
        }

        public int UpdateTransactions(Transactions transaction)
        {
            var existingTransaction = _transactions.FindIndex(t => t.Id == transaction.Id);
            if (existingTransaction != -1)
            {
                _transactions[existingTransaction] = transaction;
                return 1;
            }
            return 0;
        }

        public int DeleteTransactions(int Id)
        {
            var transactions = _transactions.FirstOrDefault(t => t.Id == Id);
            if (transactions == null)
            {
                return 0;
            }

            _transactions.Remove(transactions);
            return 1;
        }

        public int UpdateTransactions(int Id)
        {
            var transactionsToRemove = _transactions.Find(t => t.Id == transactions.Id);
            if (transactionsToRemove != null)
            {
                _transactions.Remove(transactionsToRemove);
                return 1;
            }
            return 0;
        }
    }
}