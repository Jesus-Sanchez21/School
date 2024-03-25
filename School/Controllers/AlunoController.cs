using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Models;
using School.Models.ViewModels;

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
            List<Aluno> objAlunoList = _db.Alunos.Include(x => x.Turma).ToList();

            return View(objAlunoList);

        }
        // Create ------------------------------------------------------------------------
        public IActionResult Create()
        {
            AlunoCreateVM viewModel = new AlunoCreateVM();
            viewModel.TurmaList = _db.Turmas.Select(x => new SelectListItem(x.Nome, x.Id.ToString())).ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(AlunoCreateVM viewModel)
        {
            /* Validations
             * 1- If turma exists
             * 2- Listar Numero dentro de turma
             * 3-If número in Aluno Already exists 
             */


            Aluno model = new Aluno()
                {
                    Nome = viewModel.Nome,
                    Numero = viewModel.Numero,
                    Idade = viewModel.Idade,
                    TurmaId = viewModel.TurmaId,
                };

                _db.Alunos.Add(model);
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
            Aluno? alunoFromDb = _db.Alunos.Find(id);
            if (alunoFromDb == null)
            {
                return NotFound();
            }
            return View(alunoFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Aluno? obj = _db.Alunos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Alunos.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
