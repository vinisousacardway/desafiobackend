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
        Task<RetailesDto> Create(RetailesCreateDTO model);
        Task<List<RetailesDto>> Read();
        Task<RetailesDto> Read(int id);
        Task<RetailesDto> Update(RetailesDto model);
        Task Delete(int id);
    }
}