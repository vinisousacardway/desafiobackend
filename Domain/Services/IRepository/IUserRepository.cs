using desafiobackend.Domain.Entities;
using desafiobackend.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desafiobackend.Domain.Services.Interfaces;


namespace desafiobackend.Domain.Services.Repository
{
    
        public interface IUserRepository : IGeneric<Controllers.UserCreateDto>
        {
            Task<UserDTO> Create(UserCreateDto model);
            Task<List<UserDTO>> Read();
            Task<UserDTO> Read(int id);
            Task<UserDTO> Update(UserCreateDto model);
            Task Delete(int id);
        }
}

