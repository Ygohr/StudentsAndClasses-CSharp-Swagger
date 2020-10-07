using System;
using System.Collections.Generic;
using System.Linq;
using DesafioTecnicoMarlin.Context;
using DesafioTecnicoMarlin.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioTecnicoMarlin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        private readonly DesafioContext _DesafioContext;

        public AlunoController(DesafioContext DesafioContext)
        {
            _DesafioContext = DesafioContext;
        }

        // GET: api/<AlunoController>
        [HttpGet]
        [Authorize]
        public IEnumerable<Aluno> Get()
        {
            return _DesafioContext.t_Aluno;
        }

        // GET api/<AlunoController>/5
        [HttpGet("{id}")]
        [Authorize]
        public Aluno Get(int id)
        {
            return _DesafioContext.t_Aluno.SingleOrDefault(a => a.id == id);
        }

        // POST api/<AlunoController>
        [HttpPost]
        [Authorize]
        public string Post([FromBody] MatriculaAluno matriculaAluno)
        {
            try
            {
                var qtdAluno = _DesafioContext.t_Turma_Aluno.Count(ta => ta.idTurma == matriculaAluno.turma.id);
                  
                if (qtdAluno < 5)
                {
                    _DesafioContext.t_Aluno.Add(matriculaAluno.aluno);
                    _DesafioContext.SaveChanges();

                    var alunoInseridoId = (_DesafioContext.t_Aluno.SingleOrDefault(a => a.matricula == matriculaAluno.aluno.matricula)).id;

                    TurmaAluno turmaAluno = new TurmaAluno();

                    turmaAluno.idAluno = alunoInseridoId;
                    turmaAluno.idTurma = matriculaAluno.turma.id;

                    _DesafioContext.t_Turma_Aluno.Add(turmaAluno);
                    _DesafioContext.SaveChanges();

                    return "Sucesso na inserção";
                } else
                {
                    return "Turma escolhida possui 5 alunos";
                }

            } catch(Exception ex)
            {
                return "Erro na inserção do aluno: " + ex.Message;
            }                                  
        }

        // PUT api/<AlunoController>/5
        [HttpPut("{id}, {matricula}")]
        [Authorize]
        public string Put(int id, int matricula, [FromBody] Aluno aluno)
        {
            try
            {
                aluno.id = id;
                aluno.matricula = matricula;
                _DesafioContext.t_Aluno.Update(aluno);
                _DesafioContext.SaveChanges();
                return "Sucesso na edição do aluno";
            } catch(Exception ex)
            {
                return "Erro na edição do aluno: " + ex.Message;
            }
        }

        // DELETE api/<AlunoController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public string Delete(int id)
        {
            var aluno = _DesafioContext.t_Aluno.FirstOrDefault(a => a.id == id);

            var temTurma = _DesafioContext.t_Turma_Aluno.FirstOrDefault(ta => ta.idTurma == id);

            try
            {
                if (aluno != null & temTurma == null)
                {
                    _DesafioContext.t_Aluno.Remove(aluno);
                    _DesafioContext.SaveChanges();

                    return "Sucesso na exclusão do aluno";
                }
                else
                {
                    return "Erro na exclusão, verifique se registro desejado existe ou se o aluno está associado em alguma turma";
                }
            } catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}