using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using School.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;

namespace School.Models.ViewModels
{
    public class AlunoCreateVM
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public int Numero { get; set; }
        public int TurmaId { get; set; }

        //Info
        [ValidateNever]
        public List<SelectListItem> TurmaList { get; set; }
    }
}
