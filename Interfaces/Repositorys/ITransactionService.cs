using System.Transactions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafiobackend.Interfaces.Repositorys
{
    public class ITransactionService
    {
        
            private readonly desafiobackend;

            public Task<Transaction> Create(Transaction model)
            {
                try
                {
                Transaction newAccount = _mapper.Map<Transaction, Transaction>(model);

                    

                Transaction accountResponse = _mapper.Map<Transaction, Transaction>(newAccount);

                    return Task.FromResult(accountResponse);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possivel criar conta: " + ex.Message);
                }
            }

            public Task<List<Transaction>> Read()
            {
                try
                {
                    List<Transaction> accounts = _context.Accounts.ToList();

                    List<Transaction> accountsReponse = _mapper.Map<List<Transaction>, List<Transaction>>(accounts);

                    return Task.FromResult(accountsReponse);
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possivel listar contas: " + ex.Message);
                }
            }

            public Task<Transaction> Read(int id)
            {
                try
                {
                    Transaction account = _context.Accounts.Find(id);

                    if (account is not null)
                    {
                        Transaction accountResponse = _mapper.Map<Transaction, Transaction>(account);

                        return Task.FromResult(accountResponse);
                    }
                    else
                    {
                        throw new Exception("Conta não encontrado");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possivel retornar conta: " + ex.Message);
                }
            }

            public Task<Transaction> Update(Transaction model)
            {
                try
                {
                    Transaction account = _context.Accounts.Find(model.Id);

                    if (account is not null)
                    {
                        _mapper.Map(model, account);
                        _context.Update(account);
                        _context.SaveChanges();

                        Transaction accountResponse = _mapper.Map<Transaction, Transaction>(account);

                        return Task.FromResult(accountResponse);
                    }
                    else
                    {
                        throw new Exception("Conta não encontrada");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possivel atualizar conta: " + ex.Message);
                }
            }
            public Task Delete(int id)
            {
                try
                {
                    Transaction transactions = _context.Accounts.Find(id);

                    if (Transaction is not null)
                    {
                        _context.Transactions.Remove(Transaction);
                        return Task.CompletedTask;
                    }
                    else
                    {
                        throw new Exception("Conta não encontrado");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Não foi possivel remover conta: " + ex.Message);
                }
            }
        }
    }
}
}
