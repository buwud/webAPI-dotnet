using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Nilvera.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
