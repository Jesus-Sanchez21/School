using Microsoft.AspNetCore.Mvc;
using School.Data;
using School.Models;

namespace School.Controllers
{
    public class AlunoController : Controller
    {

        private readonly AppDbContext _db;

        public AlunoController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Aluno> objAlunoList = _db.Alunos.ToList();
            return View(objAlunoList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
