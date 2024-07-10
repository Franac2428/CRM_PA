using Microsoft.AspNetCore.Mvc;

namespace CRM.Controllers
{
    public class ServiciosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
