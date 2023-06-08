namespace ReadStoredProcedure.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public bool EstaMatriculado { get; set; }
        public string Disciplina { get; set; }
    }
}
