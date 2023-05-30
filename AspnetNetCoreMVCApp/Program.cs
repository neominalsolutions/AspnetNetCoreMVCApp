using AspnetNetCoreMVCApp.Data;
using AspnetNetCoreMVCApp.Entities;
using AspnetNetCoreMVCApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// servis registeration i�lemi
builder.Services.AddTransient<EmailService>();

// veri taban� ba�lant� kodu
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
// uygulama build olmadan �nce servisleri sisteme tan�t�lm�� olmas� laz�m.

var app = builder.Build();


// uygulma servisleri tan�mlay�p uygulama i�erisinde kullan�lacak ara yaz�l�mlar sisteme tan�t�l�yor.

// her bir istek de kod buradaki middleware d��er




app.Use(async (context, next) =>
{
  // t�m uygulamay� ilgilendiren bir yap�s� olmas�.
  if(context.Request.Method == HttpMethods.Get)
  {

    // context.Response.StatusCode = 500;

    await next();
  }
  else
  {
    // next ile s�re� bir sonraki middleware aktar�l�r
    await next();
  }



});


// Config dosyas�nda de�er okuma
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

// k�sa devre yapar. uygulama �al���p response d�ner.
app.Run();
