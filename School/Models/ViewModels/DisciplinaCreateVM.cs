using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace School.Models.ViewModels
{
    public class DisciplinaCreateVM
    {
        public string Nome { get; set; }
        public string Ano { get; set; }
        public string ProfessorId { get; set; }

        [ValidateNever]
        public List<SelectListItem> ProfessorList { get; set; }
    }
}
