using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Turma
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome da turma")]
        [StringLength(20, ErrorMessage ="O nome da turma tem um máximo de 20 caracteres")]
        public string Nome { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "O ano deve estar entre 1 e 12")]
        public int Ano { get; set; }
    }
}
