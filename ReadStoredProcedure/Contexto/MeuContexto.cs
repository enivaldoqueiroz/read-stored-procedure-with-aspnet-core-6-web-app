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

        public void InserAluno(Aluno aluno)
        {
            try
            {
                Database.ExecuteSqlRaw("EXEC InsertAluno @paramNome, @paramIdade, @paramEstaMatriculado, @paramDisciplina",
                new SqlParameter("@paramNome", aluno.Nome),
                new SqlParameter("@paramIdade", aluno.Idade),
                new SqlParameter("@paramEstaMatriculado", aluno.EstaMatriculado),
                new SqlParameter("@paramDisciplina", aluno.Disciplina));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Aluno> GetAlunos()
        {
            var resultado = Alunos.FromSqlInterpolated($"EXEC GetAlunos").ToList();
            return resultado;
        }

        public void ExecutarStoredProcDeleteAluno(int alunoId)
        {
            Database.ExecuteSqlRaw("EXEC DeleteAluno @paramAlunoId",
                new SqlParameter("@paramAlunoId", alunoId));
        }
    }
}
