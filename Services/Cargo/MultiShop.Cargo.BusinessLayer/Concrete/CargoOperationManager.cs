using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BusinessLayer.Concrete
{
    public class CargoOperationManager : ICargoOperationService
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationManager(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        public void TDelete(int id)
        {
            _cargoOperationService.TDelete(id);
        }

        public List<CargoOperation> TGetAll()
        {
            return _cargoOperationService.TGetAll();
        }

        public CargoOperation TGetById(int id)
        {
            return _cargoOperationService.TGetById(id);
        }

        public void TInsert(CargoOperation entity)
        {
            _cargoOperationService.TInsert(entity);
        }

        public void TUpdate(CargoOperation entity)
        {
            _cargoOperationService.TUpdate(entity);
        }
    }
}
