using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using MultiShop.Comment.Context;

var builder = WebApplication.CreateBuilder(args);

//Identityserver'ýn comment mikroservisine dahil edilebilmesi için bu ayarýn yapýlmasý gerekiyor.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"]; //Appsettingsten comment mikroservisi ile birlikte identityserver'ýn da ayaða kalkmasý için kullanýlýyor.
    opt.Audience = "ResourceComment"; //Token'a sahipse hangi sayfalara eriþim saðlayacak. Config içerisinde ResourceCatalog'a sahip kullanýcýnýn hangi yetkilere sahip olduðu var.
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
