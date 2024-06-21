using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using desafiobackend.Domain.Entities;
using System.Linq;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using desafiobackend.Domain.Dtos;
using desafiobackend.Domain.Services.Repository;

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
        public ActionResult<IEnumerable<Retailer>> Get(Task<List<RetailerDto>> retailerList)
        {
            try
            {
                return Ok(retailerList.Result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            [HttpGet("{id:int}")]

            ActionResult<Retailer> GetById([FromRoute] int id)
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
            ActionResult AddRetailer([FromBody] Retailer retailer)
            {
                var result = retailers.FirstOrDefault(f => f.Email == retailer.Email);
                if (result != null)
                    result = retailers.FirstOrDefault(f => f.Document == retailer.Document);
                if (result != null)

                    return BadRequest("Usuario já cadastrado");

                retailer.Id = retailers.Count + 1;
                retailers.Add(retailer);

                return CreatedAtAction(nameof(GetById), new { id = retailer.Id }, retailer);
            }

            [HttpPut("{id:int}")]
            ActionResult UpdateRetailer([FromRoute] int id, [FromBody] Retailer retailer)
            {
                var result = retailers.FirstOrDefault(u => u.Id == id);
                if (result == null)
                    return NotFound(null);

                result.FullName = retailer.FullName;
                result.Password = retailer.Password;
                result.Email = retailer.Email;

                return Ok();
            }


            [HttpPost]

            [HttpDelete("{id}")]
            ActionResult DeleteRetailer(int id)
            {
                Retailer result = retailers.FirstOrDefault(u => u.Id == id);
                if (result == null)
                    return NotFound();

                retailers.Remove(result);
                return Ok(result);
            }
        }
    }


}

