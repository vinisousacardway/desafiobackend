using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace desafiobackend.Controllers
{
    [Route("retailers")]
    [ApiController]
    public class RetailersController : ControllerBase
    {
        private readonly static List<Retailer> retailers = new List<Retailer>();

        private readonly ILogger<RetailersController> _logger;

        public RetailersController(ILogger<RetailersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Retailer>> Get()
        {
            return Ok(retailers);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Retailer> GetById([FromRoute] int id)
        {
            if (id == default(int))
            {
                return BadRequest("Id existente");
            }

            Retailer result = retailers.FirstOrDefault(u => u.Id == id);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddRetailer([FromBody] Retailer retailer)
        {
            var result = retailers.FirstOrDefault(f => f.Email == retailer.Email);
            if (result != null)
                return BadRequest("Usuario já cadastrado");

            retailer.Id = retailers.Count + 1;
            retailers.Add(retailer);

            return CreatedAtAction(nameof(GetById), new { id = retailer.Id }, retailer);
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateRetailer([FromRoute]int id, [FromBody] Retailer retailer)
        {
            var result = retailers.FirstOrDefault(u => u.Id == id);
            if (result == null)
                return NotFound(null);

            result.FullName = retailer.FullName;
            result.Password = retailer.Password;
            result.Email = retailer.Email;

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRetailer(int id)
        {
            Retailer result = retailers.FirstOrDefault(u => u.Id == id);
            if (result == null)
                return NotFound();

            retailers.Remove(result);
            return Ok(result);
        }
    }

    public class Retailer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}