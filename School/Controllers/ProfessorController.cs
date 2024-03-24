using Microsoft.AspNetCore.Mvc;

namespace School.Controllers
{
    public class ProfessorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
