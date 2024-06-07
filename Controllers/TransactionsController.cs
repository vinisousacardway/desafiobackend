using desafiobackend.Domain.Dtos;
using desafiobackend.Domain.Entities;
using desafiobackend.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
using System.Transactions;

namespace desafiobackend.Controllers
{
    [Route("transaction")]
    [ApiController]
    public class TransactionController : ControllerBase

    {
        private readonly ITransactionsService _transactionsService;

        public TransactionController(ITransactionsService transactionService)
        {
            _transactionsService = transactionService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Transactions>> GetTransactions()
        {
            var transactions = _transactionsService.GetTransactions();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public ActionResult<Transactions> GetTransaction(int id)
        {
            var transaction = _transactionsService.GetTransaction(id);
            if (transaction == null)
            {
                return Ok();
            }
            return Ok(transaction);
        }

        [HttpPost]
        public ActionResult<Transactions> PostTransactions([FromBody] Transactions transaction)
        {
            _transactionsService.AddTransaction(transaction);
            return CreatedAtAction(nameof(GetTransactions), new { id = transaction }, transaction);
        }

    }
}