using System;
using System.Collections.Generic;
using System.Linq;
using DesafioTecnicoMarlin.Context;
using DesafioTecnicoMarlin.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DesafioTecnicoMarlin.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {

        private readonly DesafioContext _DesafioContext;

        public TurmaController(DesafioContext DesafioContext)
        {
            _DesafioContext = DesafioContext;
        }

        // GET: api/<TurmaController>
        [HttpGet]
        [Authorize]
        public IEnumerable<Turma> Get()
        {
            return _DesafioContext.t_Turma;
        }

        // GET api/<TurmaController>/5
        [HttpGet("{id}")]
        [Authorize]
        public Turma Get(int id)
        {
            return _DesafioContext.t_Turma.SingleOrDefault(t => t.id == id);
        }

        // POST api/<TurmaController>
        [HttpPost]
        [Authorize]
        public string Post([FromBody] Turma turma)
        {
            try
            {
                _DesafioContext.t_Turma.Add(turma);
                _DesafioContext.SaveChanges();

                return "Sucesso na inserção";
            }
            catch (Exception ex)
            {
                return "Erro na inserção: " + ex.Message;
            }

        }

        // PUT api/<TurmaController>/5
        [HttpPut("{id}")]
        [Authorize]
        public string Put(int id, [FromBody] Turma turma)
        {
            try
            {
                turma.id = id;
                _DesafioContext.t_Turma.Update(turma);
                _DesafioContext.SaveChanges();
                return "Sucesso na edição da turma";
            }
            catch (Exception ex)
            {
                return "Erro na edição da turma: " + ex.Message;
            }
        }

        // DELETE api/<TurmaController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public string Delete(int id)
        {
            var turma = _DesafioContext.t_Turma.FirstOrDefault(t => t.id == id);

            var turmaAluno = _DesafioContext.t_Turma_Aluno.FirstOrDefault(ta => ta.idTurma == id);

            try
            {
                if (turma != null & turmaAluno == null)
                {
                    _DesafioContext.t_Turma.Remove(turma);
                    _DesafioContext.t_Turma_Aluno.Remove(turmaAluno);
                    _DesafioContext.SaveChanges();

                    return "Sucesso na exclusão da turma";
                }
                else
                {
                    return "Erro na exclusão, verifique se a turma possui aluno associado";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
