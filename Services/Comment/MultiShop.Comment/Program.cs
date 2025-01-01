using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using MultiShop.Comment.Context;

var builder = WebApplication.CreateBuilder(args);

//Identityserver'�n comment mikroservisine dahil edilebilmesi i�in bu ayar�n yap�lmas� gerekiyor.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"]; //Appsettingsten comment mikroservisi ile birlikte identityserver'�n da aya�a kalkmas� i�in kullan�l�yor.
    opt.Audience = "ResourceComment"; //Token'a sahipse hangi sayfalara eri�im sa�layacak. Config i�erisinde ResourceCatalog'a sahip kullan�c�n�n hangi yetkilere sahip oldu�u var.
    opt.RequireHttpsMetadata = false; //https kullanmayacaksak.
});

// Add services to the container.
builder.Services.AddDbContext<CommentContext>();
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
