using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddressByIdQuery //Query klasörü listeleme işlemlerindeki parametreleri tutuyor.
    {
        public int Id { get; set; } //Bu sınıfı çağırırken Id parametresi ile çağırıyoruz.

        public GetAddressByIdQuery(int id)
        {
            Id = id;
        }

    }
}
