using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands
{
    public class RemoveAddressCommand //Remove işlemi için id parametrelerini bu sınıf üzerinden çağıracağız.
    {
        public int Id { get; set; } //Bu sınıfı çağırırken Id parametresi ile çağırıyoruz.

        public RemoveAddressCommand(int id)
        {
            Id = id;
        }
    }
}
