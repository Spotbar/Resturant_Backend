using Resturant_Backend.DataAccess.Factory;
using Resturant_Backend.DataAccess.Repository;
using Resturant_Backend.Domain.DTO;
using Resturant_Backend.Domain.Entities;

namespace Resturant_Backend.Business
{
    public class FactorService : IFactorService
    {

        private readonly IFactorRepository _repository;
        private readonly FactorFactory _FactorFactory;


        public FactorService(IFactorRepository repository,
            FactorFactory FactorFactory)
        {
            _repository = repository;
            _FactorFactory = FactorFactory;
        }
        public  IEnumerable<FactorDTO> GetAllFactorAsync()
        {
            var Factors =  _repository.GetFactorsAsync().Result;
            foreach (var item in Factors)
            {

                yield return (FactorDTO)item;
            }
           // return Factors;
        }
        public async Task<FactorDTO?> Get_FactorByIdAsync(string FactorId)
        {
            FactorDTO Factor = await _repository.Get_FactorByIdAsync(Guid.Parse( FactorId));
            return Factor;
        }
        public async Task<FactorDTO?> Get_FactorByFactorNumberAsync(string FactorName)
        {
            FactorDTO Factor = await _repository.Get_FactorByFactorNumber(FactorName);
            return Factor;
        }

        public async Task CreateFactorAsync(FactorDTO factor)
        {
            var res = _FactorFactory.CreateFactor(factor.FactorNumber,
                factor.FactorDate,
                factor.DeliveryCost,
                factor.FactorAmount,
                factor.IsClosed,
                factor.IsDeliveryByCompanyPaid,
                factor.Restaurant.Id);

            await _repository.AddFactorAsync(res);
            await _repository.SaveChangesAsync();
        }

        public async Task UpdateFactorAsync(FactorDTO factor)
        {
            var res = _FactorFactory.UpdateFactor(factor.Id,
                factor.FactorNumber,
                factor.FactorDate,
                factor.DeliveryCost,
                factor.FactorAmount,
                factor.IsClosed,
                factor.IsDeliveryByCompanyPaid,
                factor.Restaurant.Id);

             _repository.UpdateFactor(res);
            await _repository.SaveChangesAsync();
        }


    }
}
