using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using School.Data;
using School.Models;
using School.Models.ViewModels;

namespace School.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly AppDbContext _db;

        public ProfessorController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Professor> objProfessor = _db.Professores.ToList();
            return View(objProfessor);
        }

        // Create -------------------------------------------------------------------------------
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Professor obj)
        {
            if (ModelState.IsValid)
            {
                _db.Professores.Add(obj);
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
            Professor? professorFromDb = _db.Professores.Find(id);
            if (professorFromDb == null)
            {
                return NotFound();
            }
            return View(professorFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Professor? obj = _db.Professores.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Professores.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
