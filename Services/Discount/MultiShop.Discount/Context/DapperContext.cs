using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
    public class DapperContext:DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Tabloları veritabanına yansıtmak için kullanılır. Sonrasında bağlantı burdan kaldırılıp appsettings üzerinden devam edecek.
        {
            optionsBuilder.UseSqlServer("Server=LENOVO-PC\\SQLEXPRESS; initial Catalog=MultiShopDiscountDb; integrated Security=true;");
        }
        public DbSet<Coupon> Coupons { get; set; } //Veritabanına Coupons ismi ile yansıtacak.
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString); //CreateConnection çağırılınca yeni bir sql bağlantısı oluşturulacka.
    }
}
