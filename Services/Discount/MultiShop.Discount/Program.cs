using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.Discount.Context;
using MultiShop.Discount.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<DapperContext>(); //ilk olarak dapper'ý dahil ediyoruz.
builder.Services.AddTransient<IDiscountService, DiscountService>();

//Identityserver'ýn discount mikroservisine dahil edilebilmesi için bu ayarýn yapýlmasý gerekiyor.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"]; //Appsettingsten discount mikroservisi ile birlikte identityserver'ýn da ayaða kalkmasý için kullanýlýyor.
    opt.Audience = "ResourceDiscount"; //Token'a sahipse hangi sayfalara eriþim saðlayacak. Config içerisinde ResourceCatalog'a sahip kullanýcýnýn hangi yetkilere sahip olduðu var.
    opt.RequireHttpsMetadata = false; //https kullanmayacaksak.
});

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
