﻿using Microsoft.AspNetCore.Mvc;
using ReadStoredProcedure.Models;
using ReadStoredProcedure.Services;

namespace ReadStoredProcedure.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly MeuContexto _contexto;

        public AlunosController (MeuContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost("novo-aluno-without-procedure")]
        public IActionResult Post(Aluno aluno)
        {
            var novoAluno = new Aluno
            {
                Nome = aluno.Nome,
                Idade = aluno.Idade,
                EstaMatriculado = aluno.EstaMatriculado,
                Disciplina = aluno.Disciplina
            };

            _contexto.Alunos.Add(novoAluno);
            _contexto.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = aluno.AlunoId }, aluno);
        }

        [HttpPost("novo-aluno-with-procedure")]
        public IActionResult PostWithProcedure(Aluno aluno)
        {
            var novoAluno = new Aluno
            {
                Nome = aluno.Nome,
                Idade = aluno.Idade,
                EstaMatriculado = aluno.EstaMatriculado,
                Disciplina = aluno.Disciplina
            };

            _contexto.InserAluno(novoAluno);
            _contexto.SaveChanges();
            
            return CreatedAtAction(nameof(GetById), new { id = aluno.AlunoId }, aluno);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _contexto.Alunos.Find(id);

            if (aluno == null)
            {
                return NotFound();
            }

            return Ok(aluno);
        }

        [HttpGet]
        public IActionResult GetByAlunos()
        {
            var resultado = _contexto.GetAlunos();
            return Ok(resultado);
        }

        [HttpDelete("deletar-without-procedure/{id:int}")]
        public IActionResult Delete(int id)
        {
            var aluno = _contexto.Alunos.Find(id);

            if (aluno == null)
            {
                return NotFound();
            }

            _contexto.Alunos.Remove(aluno);

            return NoContent();
        }

        [HttpDelete("deletar-with-procedure/{id:int}")]
        public IActionResult DeleteWithProcedure(int id)
        {
            var aluno = _contexto.Alunos.Find(id);

            if (aluno == null)
            {
                return NotFound();
            }

            _contexto.ExecutarStoredProcDeleteAluno(aluno.AlunoId);

            return NoContent();
        }
    }
}
