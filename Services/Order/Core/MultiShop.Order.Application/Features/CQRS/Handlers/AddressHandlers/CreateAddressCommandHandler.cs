using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler //Handler içerisine CRUD işlemleri yazılır. Ekleme silme ve güncelleme gibi işlemlerde isimlendirilirken CommandHandler yazılır.
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand) //CQRS de method ismi olarak Handle  kullanılır.
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City, //Mapleme kullansaydık bu şekilde tek tek atama yapmamıza gerek kalmayacaktı.
                Detail1 = createAddressCommand.Detail1,
                District = createAddressCommand.District,
                UserId = createAddressCommand.UserId,
                Country = createAddressCommand.Country,
                Description = createAddressCommand.Description,
                Detail2 = createAddressCommand.Detail2,
                Email = createAddressCommand.Email,
                Name = createAddressCommand.Name,
                Phone = createAddressCommand.Phone,
                Surname = createAddressCommand.Surname,
                ZipCode = createAddressCommand.ZipCode
            });
        }
    }
}
