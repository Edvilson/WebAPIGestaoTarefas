using Microsoft.AspNetCore.Mvc;
using WebAPIGestaoTarefas.Context;
using WebAPIGestaoTarefas.Model;

namespace WebAPIGestaoTarefas.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaContainer _container;

        public TarefaController(TarefaContainer container)
        {
            _container = container;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Tarefa>> ObterTodasTarefas()
        {
            var tarefas = _container.ObterTodasTarefas();
            if (tarefas == null)
            {
                return NotFound("Não existem tarefas cadastradas.");
            }
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public ActionResult<Tarefa> ObterTarefaPorId(int id)
        {
            var tarefa = _container.ObterTarefaPorId(id);
            if (tarefa == null)
            {
                return NotFound("Tarefa não encontrada.");
            }
            return tarefa;
        }

        [HttpPost]
        public ActionResult<Tarefa> Incluir(Tarefa tarefa)
        {            
            _container.Incluir(tarefa);
            return CreatedAtAction(nameof(ObterTarefaPorId), new { id = tarefa.Id }, tarefa);
        }

        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Tarefa tarefa)
        {

            _container.Alterar(id, tarefa);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            var result = _container.Excluir(id);
            if (!result)
            {
                return NotFound("Tarefa não encontrada.");
            }
            return NoContent();
        }
    }
}
