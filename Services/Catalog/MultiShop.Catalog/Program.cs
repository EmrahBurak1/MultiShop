using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MultiShop.Catalog.Mapping;
using MultiShop.Catalog.Services.AboutServices;
using MultiShop.Catalog.Services.BrandServices;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ContactServices;
using MultiShop.Catalog.Services.FeatureServices;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Services.OfferDiscountServices;
using MultiShop.Catalog.Services.ProductDetailDetailServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.SpecialOfferServices;
using MultiShop.Catalog.Services.StaticticServices;
using MultiShop.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoryService, CategoryService>(); //Addscoped uygulamada method �a��r�ld���nda bunun nesne �rne�ini olu�turmu� olur. Registration i�lemi bu �ekilde yap�lm�� olur.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IStaticticService, StatisticService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); //Automapper konfigurasyonu da bu �ekilde yap�l�r. 

//Identityserver'�n catalog mikroservisine dahil edilebilmesi i�in bu ayar�n yap�lmas� gerekiyor.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"]; //Appsettingsten catalog mikroservisi ile birlikte identityserver'�n da aya�a kalkmas� i�in kullan�l�yor.
    opt.Audience = "ResourceCatalog"; //Token'a sahipse hangi sayfalara eri�im sa�layacak. Config i�erisinde ResourceCatalog'a sahip kullan�c�n�n hangi yetkilere sahip oldu�u var.
    opt.RequireHttpsMetadata = false; //https kullanmayacaksak.
});

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings")); //Bu �ekilde appsetting i�inde bulunan DatabaseSettings burada konfigurasyon olarak eklenir.

builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
}); //Bu konfigurasyon ayar�nda da Database settings s�n�f� i�indeki valuelara yani tablo isimleri, conn string, veritaban� ismi gibi bilgileri almak i�in kullan�l�yor.

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
