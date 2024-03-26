using Microsoft.AspNetCore.Mvc;
using School.Data;
using School.Models;

namespace School.Controllers
{
    public class TurmaController : Controller
    {
        private readonly AppDbContext _db;

        public TurmaController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Turma> objTurmaList = _db.Turmas.ToList();
            return View(objTurmaList);
        }

        // Create ------------------------------------------------------------------------
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Turma obj)
        {
            bool containsNumber = obj.Nome.Any(char.IsDigit);
            if (
                containsNumber ||
                String.IsNullOrWhiteSpace(obj.Nome) ||
                (obj.Ano < 1 && obj.Ano > 12)
               )
            {

                return RedirectToAction("Create");
            }
            if (ModelState.IsValid)
            {
                _db.Turmas.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        //Delete --------------------------------------------------------------------------
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Turma? turmaFromDb = _db.Turmas.Find(id);
            if (turmaFromDb == null)
            {
                return NotFound();
            }
            return View(turmaFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Turma? obj = _db.Turmas.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Turmas.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
