using desafiobackend.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafiobackend.Domain.Services.Repository
{
    public interface IRetailesRepositorycs
    {
        Task<RetailerDto> Create(RetailerCreateDto model);
        Task<List<RetailerDto>> Read();
        Task<RetailerDto> Read(int id);
        Task<RetailerDto> Update(RetailerUpdateDto model);
        Task Delete(int id);
    }
}