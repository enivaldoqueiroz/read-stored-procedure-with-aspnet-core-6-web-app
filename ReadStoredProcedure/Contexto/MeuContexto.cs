using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ReadStoredProcedure.Model;
using ReadStoredProcedure.Models;

namespace ReadStoredProcedure.Services
{
    public class MeuContexto : DbContext
    {
        public MeuContexto(DbContextOptions<MeuContexto> options) : base(options) { }

        public DbSet<MeuModelo> MeusModelos { get; set; }

        public DbSet<Aluno> Alunos { get; set; }

        public IEnumerable<MeuModelo> ExecutarMinhaStoredProcedure()
        {
            var resultado = MeusModelos.FromSqlInterpolated($"EXEC MinhaStoredProcedure").ToList();
            return resultado;
        }

        public void InserAlunoById(Aluno aluno)
        {
            Database.ExecuteSqlRaw("EXEC InsertAlunoById @paramNome, @paramIdade, @paramEstaMatriculado, @paramDisciplina",
                new SqlParameter("@paramNome", aluno.Nome),
                new SqlParameter("@paramIdade", aluno.Idade),
                new SqlParameter("@paramEstaMatriculado", aluno.EstaMatriculado),
                new SqlParameter("@paramDisciplina", aluno.Disciplina));
        }

        public IEnumerable<Aluno> GetAlunos()
        {
            var resultado = Alunos.FromSqlInterpolated($"EXEC GetAlunos").ToList();
            return resultado;
        }
    }
}
