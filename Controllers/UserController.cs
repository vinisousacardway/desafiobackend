using desafiobackend.Domain.Dtos;
using desafiobackend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace desafiobackend.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly static List<User> usuarios = new List<User>();

        private readonly ILogger<UserController> _logger;


        public UserController(ILogger<UserController> logger)
        {
            _logger = (ILogger<UserController>?)logger;
        }

        [HttpGet]
        public ActionResult<List<UserCreateDto>> Get()
        {
            return Ok(usuarios);
        }

        [HttpGet("{id:int}")]
        public ActionResult<User> GetById([FromRoute] int id)
        {
            if (id <= 0)
            
                ModelState.AddModelError("id", "O id deve ser um número inteiro positivo.");
            
            User result = usuarios.FirstOrDefault(u => u.Id == id);
            if (result == null) 
                return Ok();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddUsuario([FromBody] UserCreateDto usuario)
        {
            var result = usuarios.FirstOrDefault(f => f.CPF_CNPJ == usuario.CPF_CNPJ);
            if (result != null)
                return BadRequest("CPF ou CNPJ já cadastrado");

            usuario.Id = usuarios.Count + 1;


            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateUsuario([FromRoute] int id, [FromBody] User usuario)
        {
           
            var user = usuarios.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                // Se o usuário não for encontrado, retorne uma resposta 404 Não encontrado
                return NotFound();
            }
            user.FullName = usuario.FullName;
            user.Email = usuario.Email;
            user.Password = usuario.Password;

            // Retornar uma resposta 200 OK com o usuário atualizado
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario([FromRoute] int id)
        {
            var result = usuarios.FirstOrDefault(f => f.Id == id);

            if (result == null)
                return Ok();

            usuarios.Remove(result);
            return Ok(result);
        }
    }

    internal class ValidFormAttribute : Attribute
    {
    }

    public class UserCreateDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

}


