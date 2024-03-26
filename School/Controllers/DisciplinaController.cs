using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Models;
using School.Models.ViewModels;

namespace School.Controllers
{
    public class DisciplinaController : Controller
    {

        private readonly AppDbContext _db;

        public DisciplinaController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Disciplina> objDisciplinaList = _db.Disciplinas.Include(x => x.Professor).ToList();

            return View(objDisciplinaList);
        }

        // Create ------------------------------------------------------------------------

        public IActionResult Create()
        {
            DisciplinaCreateVM viewModel = new DisciplinaCreateVM();
            viewModel.ProfessorList = _db.Professores.Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(Disciplina viewModel)
        {
            Professor? professor = _db.Professores.Find(viewModel.ProfessorId);
            if (professor == null)
            {
                return RedirectToAction("Create");
            }

            if (
                String.IsNullOrWhiteSpace(viewModel.Nome) ||
                (viewModel.Ano < 1 || viewModel.Ano > 12) ||
                (viewModel.ProfessorId < 1)
               )
            {

                return RedirectToAction("Create");
            }


            Disciplina model = new Disciplina()
            {
                Nome = viewModel.Nome,
                Ano = viewModel.Ano,
                ProfessorId = viewModel.ProfessorId,
            };

            _db.Disciplinas.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Delete --------------------------------------------------------------------------
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Disciplina? disciplinaFromDb = _db.Disciplinas.Find(id);
            if (disciplinaFromDb == null)
            {
                return NotFound();
            }
            return View(disciplinaFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Disciplina? obj = _db.Disciplinas.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Disciplinas.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
