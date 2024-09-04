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

        public List<CargoDetail> TGetAll()
        {
            return _cargoOperationService.TGetAll();
        }

        public CargoDetail TGetById(int id)
        {
            return _cargoOperationService.TGetById(id);
        }

        public void TInsert(CargoDetail entity)
        {
            _cargoOperationService.TInsert(entity);
        }

        public void TUpdate(CargoDetail entity)
        {
            _cargoOperationService.TUpdate(entity);
        }
    }
}
