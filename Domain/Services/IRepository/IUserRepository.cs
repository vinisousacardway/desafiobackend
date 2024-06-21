
using desafiobackend.Domain.Dtos;
using desafiobackend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using desafiobackend.Domain.Services.IGeneric;


namespace desafiobackend.Domain.Services.Repository
{

    public interface IUserRepository : IGeneric<User>
        {
            Task<UserDto> Create(UserCreateDto model);
            Task<List<UserDto>> Read();
            Task<UserDto> Read(int id);
            Task<UserDto> Update(UserUpdateDto model);
            Task Delete(int id);
        }
}

