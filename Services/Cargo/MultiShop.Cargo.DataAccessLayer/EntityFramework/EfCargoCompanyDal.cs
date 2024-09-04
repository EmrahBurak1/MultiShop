using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework
{
    //Generic sınıfta yapılamayan entity'ye özgü methodlar entityframework klasörü içerisinde ayrı ayrı sınıflarda tanımlanabilir.
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal 
    {
        public EfCargoCompanyDal(CargoContext context) : base(context) //EfCargoCompanyDal context sınıfını dahil etmemizi ister constructor olarak eklenip base olarakta context'i göndereceğimizi belirtiriz.
        {
                
        }
    }
}
