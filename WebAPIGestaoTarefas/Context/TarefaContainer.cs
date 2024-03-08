using WebAPIGestaoTarefas.Model;

namespace WebAPIGestaoTarefas.Context
{
    public class TarefaContainer
    {
        private readonly List<Tarefa> _tarefa;

        public TarefaContainer()
        {
            _tarefa = new List<Tarefa>();
        }

        public IEnumerable<Tarefa>? ObterTodasTarefas()
        {
            return _tarefa.Any() ? _tarefa : null;
        }

        public Tarefa ObterTarefaPorId(int id) => _tarefa.FirstOrDefault(tarefa => tarefa.Id == id);

        public void Incluir(Tarefa tarefa)
        {
            tarefa.Id = Tarefa.NextId++;
            tarefa.Status = "P";
            _tarefa.Add(tarefa);
        }

        public void Alterar(int id, Tarefa model)
        {
            var tarefaExiste = _tarefa.FirstOrDefault(tarefa => tarefa.Id == id);
            if (tarefaExiste != null)
            {
                tarefaExiste.Descricao = model.Descricao;
                tarefaExiste.Status = "C";
            }
        }

        public bool Excluir(int id)
        {
            var tarefaExcluir = _tarefa.FirstOrDefault(tarefa => tarefa.Id == id);
            if (tarefaExcluir != null)
            {
                _tarefa.Remove(tarefaExcluir);
                return true;
            }
            return false;
        }
    }
}
