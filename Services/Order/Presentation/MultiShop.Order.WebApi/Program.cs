using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Application.Services;
using MultiShop.Order.Persistence.Context;
using MultiShop.Order.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OrderContext>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"]; //Appsettingsten discount mikroservisi ile birlikte identityserver'�n da aya�a kalkmas� i�in kullan�l�yor.
    opt.Audience = "ResourceOrder"; //Token'a sahipse hangi sayfalara eri�im sa�layacak. Config i�erisinde ResourceCatalog'a sahip kullan�c�n�n hangi yetkilere sahip oldu�u var.
    opt.RequireHttpsMetadata = false; //https kullanmayacaksak.
});

#region
builder.Services.AddScoped<GetAddressQueryHandler>(); //Constructor ge�ti�imiz t�m s�n�flar� Dependency injection'a ge�iyoruz.
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();

builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetOrderDetailByIdQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
#endregion

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>)); //Repository i�in registration i�lemini yapt�k.
builder.Services.AddApplicationService(builder.Configuration); //Burada da servisimizi eklemi� oluyoruz. SOLID'i ezmemek i�in MediatR'� application i�indeki services klas�r�ne ekledik. 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
