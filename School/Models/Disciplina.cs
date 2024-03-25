using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Ano { get; set; }

        public int ProfessorId { get; set; }
        [ForeignKey("ProfessorId")]
        public Professor? Professor { get; set; }
    }
}
