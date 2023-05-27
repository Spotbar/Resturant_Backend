using Microsoft.EntityFrameworkCore;
using Resturant_Backend.Domain.DbContexts;
using Resturant_Backend.Domain.Entities;

namespace Resturant_Backend.DataAccess.Repository
{
    public class FactorRepository : IFactorRepository
    {
        private readonly ApplicationDBContext _context;

        public FactorRepository(ApplicationDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Factor>> GetFactorsAsync()
        {
            return await _context.Factors
                .Include(x=>x.Restaurant)
                .ToListAsync();
        }

        public async Task<Factor?> Get_FactorByIdAsync(Guid FactorId)
        {
            return await _context.Factors
                 .Include(x => x.Restaurant)
                .FirstOrDefaultAsync(e => e.Id == FactorId);
        }
     
        public Factor? Get_FactorById(Guid FactorId)
        {
            return _context.Factors
                 .Include(x => x.Restaurant)
                .FirstOrDefault(e => e.Id == FactorId);
        }
        public async Task<Factor?> Get_FactorByFactorNumber(string? factorNumber)
        {
            if (!string.IsNullOrEmpty(factorNumber))
            {
                return await _context.Factors
                     .Include(x => x.Restaurant)
                .FirstOrDefaultAsync(e => e.FactorNumber.Equals(factorNumber));
            }
            return new Factor();
        }


        public List<Factor> GetFactors(params Guid[] FactorIds)
        {
            List<Factor> Factors = new();
            foreach (var Factorid in FactorIds)
            {
                var Factor = Get_FactorById(Factorid);
                if (Factor != null)
                {
                    Factors.Add(Factor);
                }
            }
            return Factors;
        }

        public async Task<List<Factor>> GetFactorsAsync(params Guid[] FactorIds)
        {
            List<Factor> Factors = new();
            foreach (var Factorid in FactorIds)
            {
                var Factor = await Get_FactorByIdAsync(Factorid);
                if (Factor != null)
                {
                    Factors.Add(Factor);
                }
            }
            return Factors;
        }

        public async Task AddFactorAsync(Factor Factor)
        {
             await _context.Factors.AddAsync(Factor);
        }
        public void UpdateFactor(Factor Factor)
        {
             _context.Factors.Update(Factor);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

       
    }
}
