using AspnetNetCoreMVCApp.Data;
using AspnetNetCoreMVCApp.Entities;
using AspnetNetCoreMVCApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// servis registeration iþlemi
builder.Services.AddTransient<EmailService>();

// veri tabaný baðlantý kodu
builder.Services.AddDbContext<NorthwindContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
});

builder.Services.AddDbContext<CustomerContext>(opt =>
{
  opt.UseSqlServer(builder.Configuration.GetConnectionString("CustomerConn"));
});



// IoC Container
// Autofac, Ninject, Unity, Castle Windsor
// uygulama build olmadan önce servisleri sisteme tanýtýlmýþ olmasý lazým.

var app = builder.Build();


// uygulma servisleri tanýmlayýp uygulama içerisinde kullanýlacak ara yazýlýmlar sisteme tanýtýlýyor.

// her bir istek de kod buradaki middleware düþer




app.Use(async (context, next) =>
{
  // tüm uygulamayý ilgilendiren bir yapýsý olmasý.
  if(context.Request.Method == HttpMethods.Get)
  {

    // context.Response.StatusCode = 500;

    await next();
  }
  else
  {
    // next ile süreç bir sonraki middleware aktarýlýr
    await next();
  }



});


// Config dosyasýnda deðer okuma
string value = builder.Configuration.GetSection("Logging").GetSection("LogLevel").Value;

string value1 = builder.Configuration["Logging:LogLevel"];

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
//app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// kýsa devre yapar. uygulama çalýþýp response döner.
app.Run();
