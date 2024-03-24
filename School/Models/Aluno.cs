using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome completo de aluno")]
        [StringLength(50, ErrorMessage ="O nome de aluno deve conter no máximo 50 caracteres")]
        public string Nome { get; set; }

        [Required]
        [Range (1, 100, ErrorMessage ="A idade deve estar entre 1 e 100")]
        public int Idade { get; set; }

        [Required]
        [Display(Name = "Número de aluno")]

        public int Numero { get; set; }
    }
}
