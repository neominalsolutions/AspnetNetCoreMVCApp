using AspnetNetCoreMVCApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspnetNetCoreMVCApp.Controllers
{
  public class ManyToManyTestController : Controller
  {
    private readonly CustomerContext customerContext;

    public ManyToManyTestController(CustomerContext customerContext)
    {
      this.customerContext = customerContext;
    }

    public IActionResult Index()
    {

     var result =  this.customerContext.ATable.Include(x=> x.BList).SelectMany(x => x.BList).Where(x=> x.Id == 3).ToList();

      return View();
    }
  }
}
