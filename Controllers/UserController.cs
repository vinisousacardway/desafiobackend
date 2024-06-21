using desafiobackend.Domain.Dtos;
using desafiobackend.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace desafiobackend.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly static List<User> Users = new List<User>()
        {
            new User
                {
                    Id = 1,
                    Email = "string",
                    FullName = "string",
                    Document = "1234"
                }
        };
        private readonly ILogger<UserController> _logger;

        [HttpGet]
        public ActionResult<List<User>> Get()
        {

            return Ok(Users);
        }

        //BackgroundService BackgroundService { get; set; } // Remover

        [HttpGet("{id:int}")]
        public ActionResult<User> GetById([FromRoute] int id)
        {
            if (id <= 0)
                ModelState.AddModelError("id", "O id deve ser um número inteiro positivo."); // 

            User result = Users.FirstOrDefault(u => u.Id == id);

            if (result == null)  // Informa que o registro do usuário nn foi encontrado.
                return Ok();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult AddUsuario([FromBody] User usuario)
        {
            var result = Users.FirstOrDefault(f => f.Document == usuario.Document);

            if (result != null)
                return BadRequest("CPF ou CNPJ já cadastrado");


            //Primeiro - Deverá pegar o maior ID na base, dai sim incrementar.
            usuario.Id = Users.Count + 1;

            // Adicionar usuáio na base.

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario); // Retornar somente o Id
        }

        [HttpPut("{id:int}")]
        public ActionResult UpdateUsuario([FromRoute] int id, [FromBody] UserUpdateDto usuario) // Não receber entidade
        {

            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                // Se o usuário não for encontrado, retorne uma resposta 404 Não encontrado
                return NotFound();
            }

            //Validar se o dado existe
            if()
            user.FullName = usuario.Name;
            user.Email = usuario.Email;
            //user.Password = usuario.Password;

            // Retornar uma resposta 200 OK com o usuário atualizado
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteUsuario([FromRoute] int id)
        {
            var result = Users.FirstOrDefault(f => f.Id == id);

            if (result == null)
                return Ok();

            Users.Remove(result);
            return Ok(result);
        }
    }

    //internal class ValidFormAttribute : Attribute
    //{
    //}

    //public class UserCreateDto // Domain > Dto
    //{
    //    public int Id { get; set; } // Remover pois quem gera o id é o sistema
    //    public string FullName { get; set; }
    //    public string Document { get; set; }
    //    public string Email { get; set; }
    //    public string Password { get; set; }
    //}

}


