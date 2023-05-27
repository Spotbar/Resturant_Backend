using Resturant_Backend.Domain.DTO;
using Resturant_Backend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant_Backend.Business
{
    public interface IFactorService
    {
        IEnumerable<FactorDTO> GetAllFactorAsync();
        Task<FactorDTO?> Get_FactorByIdAsync(string FactorId);
        Task<FactorDTO?> Get_FactorByFactorNumberAsync(string FactorNumber);

        Task CreateFactorAsync(FactorDTO Factor);

        Task UpdateFactorAsync(FactorDTO Factor);
    }
}
