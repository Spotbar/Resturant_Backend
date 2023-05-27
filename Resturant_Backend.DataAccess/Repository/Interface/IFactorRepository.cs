using Resturant_Backend.Domain.Entities;

namespace Resturant_Backend.DataAccess.Repository
{
    public interface IFactorRepository
    {
        Task<IEnumerable<Factor>> GetFactorsAsync();
        Task<Factor?> Get_FactorByIdAsync(Guid factorId);

        Factor? Get_FactorById(Guid factorId);
        Task<Factor?> Get_FactorByFactorNumber(string? factorNumber);

        List<Factor> GetFactors(params Guid[] factorIds);

        Task<List<Factor>> GetFactorsAsync(params Guid[] factorIds);

        Task AddFactorAsync(Factor factor);
        void UpdateFactor(Factor factor);


        Task SaveChangesAsync();
    }
}
