using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Services
{
    //SOLID'i ezmemek adına MediatR için registration işlemlerini doğrudan Program.cs içerisinde yapmadık. Onun yerine Application katmanına Services klasörü açıp onun içine tanımladık.
    public static class ServiceRegistration //Static tanımladık diğer yerlerde buradaki methodlara doğrudan erişebilmek için.
    {
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly)); //Bu şekilde ilgili kütüphanenin registration işlemi yapılmış olur.
        }
    }
}
