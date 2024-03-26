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
            viewModel.TurmaList = _db.Turmas.Select(x => new SelectListItem(x.Ano + "º " + x.Nome, x.Id.ToString())).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(AlunoCreateVM viewModel)
        {
            //Verifica se a turma cujo id foi selecionado na viewModel é nulo caso tenha sido apagada, se sim ent erro
            Turma? turma = _db.Turmas.Find(viewModel.TurmaId);
            if (turma == null)
            {
                return RedirectToAction("Create");
            }

            // Seleciona na tabela os numeros dos alunos em que a turma é igual à turma que passamos na viewModel
            List<int> NumeroTurmaList = _db.Alunos.Where(x => x.TurmaId == viewModel.TurmaId).Select(x => x.Numero).ToList();

            //Verificar se os numeros recolhidos tem algum igual ao da viewModel, e se sim não deixa passar
            if (NumeroTurmaList.Contains(viewModel.Numero))
            {
                return RedirectToAction("Create");
            }

            /* Verificar se nome tem números
             * Verificar se foram inseridos dados nulos ou negativos 
             * Verificar se tem idade aceitável para pelo menos o 1o ano
             */

            bool containsNumber = viewModel.Nome.Any(char.IsDigit);
            if (
                containsNumber ||
                String.IsNullOrWhiteSpace(viewModel.Nome) ||
                (viewModel.Numero < 1) ||
                (viewModel.Idade < 6 && viewModel.Idade > 19) ||
                (viewModel.TurmaId < 1)
               )
            {

                return RedirectToAction("Create");
            }

            Aluno model = new Aluno()
            {
                Nome = viewModel.Nome,
                Numero = viewModel.Numero,
                Idade = viewModel.Idade,
                Turma = turma,
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
