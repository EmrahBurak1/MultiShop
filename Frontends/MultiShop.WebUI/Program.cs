using Microsoft.AspNetCore.Authentication.JwtBearer;
using MultiShop.WebUI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Login/Index/"; //Giri� yapmadan gelen kullan�c� olursa y�nlendirece�imiz sayfa.
        opt.AccessDeniedPath = "/Login/Logout/";
        opt.AccessDeniedPath = "/Pages/AccessDenied/"; //Kullan�c� yetkisi olmayan bir sayfaya girmek istedi�inde y�nlendirece�imiz sayfa.
        opt.Cookie.HttpOnly = true; //Cookie'yi sadece HTTP �zerinden eri�ilebilir yapar.
        opt.Cookie.SameSite = SameSiteMode.None; //Cookie'nin g�venli�i i�in kullan�l�r. SameSiteMode.None: Cookie'nin g�venli�i i�in kullan�l�r. SameSiteMode.Strict: Cookie'nin g�venli�i i�in kullan�l�r. SameSiteMode.Lax: Cookie'nin g�venli�i i�in kullan�l�r.
        opt.Cookie.SecurePolicy = CookieSecurePolicy.Always; //Cookie'yi sadece HTTPS �zerinden eri�ilebilir yapar.
        opt.Cookie.Name = "MultiShopJwt"; //Cookie'nin ad�n� belirler.
    });

builder.Services.AddHttpContextAccessor(); //HttpContext'e eri�ebilmek i�in ekledik.

builder.Services.AddScoped<ILoginService, LoginService>();

// Add services to the container.
builder.Services.AddHttpClient(); //HttpClient'� kullanabilmek i�in ekledik.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints => //Admin paneli ile kullan�c� panelini ay�rmak i�in area kulland�k. Program cs'in bu areay� tan�mas� i�in bu kodu ekledik. Area olu�turunca kod otomatik gelir.
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
