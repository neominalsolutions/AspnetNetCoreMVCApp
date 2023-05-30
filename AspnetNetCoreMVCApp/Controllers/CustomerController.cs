using AspnetNetCoreMVCApp.Data;
using AspnetNetCoreMVCApp.Entities;
using AspnetNetCoreMVCApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspnetNetCoreMVCApp.Controllers
{
  public class CustomerController : Controller
  {
    private readonly NorthwindContext context;
    private readonly CustomerContext customerContext;


    public CustomerController(NorthwindContext northwindContext, CustomerContext customerContext)
    {
      this.context = northwindContext;
      this.customerContext = customerContext;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AccountCreateDto model)
    {

      if(ModelState.IsValid)
      {
        var customer = new Data.Customer(model.AccountNumber);
        await this.customerContext.AddAsync(customer);
        await this.customerContext.SaveChangesAsync();

        return View();
      }

     

      return View();
    }


    [HttpGet]
    public async Task<IActionResult> Deposit()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Deposit(DepositDto model)
    {

      if (ModelState.IsValid)
      {
        var account = await this.customerContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == model.AccountNumber);

        if (account is not null)
        {
          // entity state değişltir.
          account.Deposit(model.Amount);

          // repo yardımı ile dbye yansıt.
          this.customerContext.Accounts.Update(account);
          await this.customerContext.SaveChangesAsync();

        }

        return View();
      }



      return View();
    }




    [HttpGet]
    public async Task<IActionResult> WithDraw()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> WithDraw(WithDrawDto model)
    {

      if (ModelState.IsValid)
      {
        var account = await this.customerContext.Accounts.FirstOrDefaultAsync(x => x.AccountNumber == model.AccountNumber);

        if(account is not null)
        {
          // entity state değişltir.
          account.WithDraw(model.Amount);

          // repo yardımı ile dbye yansıt.
          this.customerContext.Accounts.Update(account);
          await this.customerContext.SaveChangesAsync();

        }

        return View();
      }



      return View();
    }



    public IActionResult Index()
    {
      var clist = this.context.Customers.ToList();


      return View();
    }

    public async Task<IActionResult> List(string type, decimal amount)
    {
      var acc = new Account("123324");


      //if (type = "Para çekme")
      //{
      //  acc.Balance =- 10;
      //  // repo.save();
      //}



      // Change Tracker
      // listeleme işlemlerinde false yapmamız gerekiyor.
      var clist = await this.context.Customers.AsNoTracking().ToListAsync();
      // asQuerable();


      var clistQuery = this.context.Customers.AsQueryable();

      clistQuery = clistQuery.Where(x => x.Country != "");

      var model =await clistQuery.ToListAsync();

      // tablolar ile veri çekerken lazy-loading yok bunun yerine Include veya Projection yöntemi var.

      var includeSample2 = this.context.Products.ToList();

      var includeSample = this.context.Products
        .Include(c => c.Category)
        .Include(x => x.Supplier)
        .ThenInclude(x => x.Products)
        .Where(x=> x.UnitPrice > 10 && x.Supplier.CompanyName == "")
        .Where(x=> x.Category != null)
        .OrderBy(x=> x.Category.CategoryName)
        .ToList();

      // where order by select list

      //var orderQuery = this.context.Orders.Include(x=> x.OrderDetails).ThenInclude(x=> x.ProductId)


      // select varsa Include ThenInclude gibi yapılara ihtiyaç duymadan join yapabiliriz.
      var joinSample = this.context.Products.Select(a => new
      {
        CategoryName = a.Category.CategoryName,
        ProductName = a.ProductName
      }).ToList();



      // pure sql query
      // select store proc veya view
      var query2 = context.Products.FromSqlRaw("select * from viewName");

      // insert update delete işlemleri store proc üzerinden
      // context.Database.ExecuteSqlRaw("");



      return View();
    }
  }
}
