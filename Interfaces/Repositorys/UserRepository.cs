using desafiobackend;
using desafiobackend.Controllers;
using desafiobackend.Domain.Entities;
using desafiobackend.Domain.Interfaces.Repositorys;
using desafiobackend.Domain.Models;
using desafiobackend.Infrastructure.Context;

namespace desafiobackend.Infrastructure.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly desafiobackend 
        private readonly IMapper _mapper;

        public UserRepository( RetailersController context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        private bool comparePasswords(string actPassword, string newPassword)
        {
            // desacoplamento do metodo de comparação de senhas.
            // caso necessario implementar criptografia a comparação de hash's pode ser feita aqui.
            return actPassword.Equals(newPassword);
        }
        private string hashPasswords(string password)
        {
            return password;
        }

        public Task<User> Create(UserCreate model)
        {
            try
            {
                User newUser = _mapper.Map<UserCreate, User>(model);

                _context.Users.Add(newUser);
                _context.SaveChanges();

                User userResponse = _mapper.Map<User, User>(newUser);

                return Task.FromResult(userResponse);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel criar usuario: " + ex.Message);
            }
        }
        public Task<List<User>> Read()
        {
            try
            {
                List<User> users = _context.Users.ToList();

                List<User> usersReponse = _mapper.Map<List<User>, List<User>>(users);

                return Task.FromResult(usersReponse);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel listar usuarios: " + ex.Message);
            }
        }
        public Task<User> Read(int id)
        {
            try
            {
                User user = _context.Users.Find(id);

                if (user is not null)
                {
                    User userResponse = _mapper.Map<User, User>(user);

                    return Task.FromResult(userResponse);
                }
                else
                {
                    throw new Exception("Usuario não encontrado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel listar usuarios: " + ex.Message);
            }
        }
        public Task<User> Update(UserUpdate model)
        {
            try
            {
                if (model is not null)
                {
                    User actUser = _context.Users.Find(model.Id);

                    if (actUser is not null)
                    {

                        if (model.NewPassword is null)
                        {
                            actUser.Name = model.Name;
                            actUser.Email = model.Email;
                            actUser.CPF = model.CPF;
                        }
                        else
                        {
                            if (comparePasswords(actUser.Password, model.CurrentPassword))
                            {
                                actUser.Password = hashPasswords(model.NewPassword);
                                actUser.Name = model.Name;
                                actUser.Email = model.Email;
                                actUser.CPF = model.CPF;
                            }
                            else
                            {
                                throw new Exception("Credênciais incorretas");
                            }
                        }

                        _context.Users.Update(actUser);
                        _context.SaveChanges();

                        User userResponse = _mapper.Map<User, User>(actUser);

                        return Task.FromResult(userResponse);
                    }
                    else
                    {
                        throw new Exception("Não foi possivel encontrar usuario");
                    }
                }
                else
                {
                    throw new Exception("O corpo da requisição não pode ser nulo");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel criar usuario: " + ex.Message);
            }
        }
        public Task Delete(int id)
        {
            try
            {
                User user = _context.Users.Find(id);

                if (user is not null)
                {
                    _context.Users.Remove(user);
                    return Task.CompletedTask;
                }
                else
                {
                    throw new Exception("Usuario não encontrado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possivel remover usuario: " + ex.Message);
            }
        }
    }
}