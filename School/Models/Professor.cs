using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Professor
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome completo de professor")]
        [StringLength(50, ErrorMessage = "O nome do professor deve conter no máximo 50 caracteres")]
        public string Nome { get; set; }

    }
}
