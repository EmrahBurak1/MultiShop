using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultiShop.Order.Application.Features.CQRS.Results.AddressResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler //Id ye göre veya tüm verileri getirme işlemlerinde isimlendirme olarak handler'ı adlandırırken QueryHandler yazılır.
    {
        private readonly IRepository<Address> _repository;

        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query) //Burada task içerisinde geri dönüş değeri bekliyor. Bunun için GetAddressByIdQueryResult tipinde olduğu belirtilir. Parametre olarak da GetAddressByIdQueryResult sınıfının Id sini tutan yeri alacak bu da GetAddressByIdQuery den alınır.
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult //Bu şekilde id ye göre veri getirme işlemi sağlanmış olur.
            {
                AddressId = values.AddressId,
                City = values.City,
                Detail = values.Detail1,
                District = values.District,
                UserId = values.UserId
            };
        }
    }
}
