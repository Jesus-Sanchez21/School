using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
    public class TurmaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
