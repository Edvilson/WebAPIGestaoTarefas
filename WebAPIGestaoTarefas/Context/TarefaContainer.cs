using TaskManager.Model;

namespace WebAPIGestaoTarefas.Context
{
    public class TarefaContainer
    {
        private readonly List<Tarefa> _tarefa;

        public TarefaContainer()
        {
            _tarefa = new List<Tarefa>();
        }

        public IEnumerable<Tarefa> ObterTodasTarefas()
        {
            return _tarefa.Any() ? _tarefa : null;
        }

        public Tarefa ObterTarefaPorId(int id) => _tarefa.FirstOrDefault(task => task.Id == id);

        public void Incluir(Tarefa task)
        {
            task.Id = Tarefa.NextId++;
            _tarefa.Add(task);
        }

        public void Alterar(int id, Tarefa updatedTask)
        {
            var existingTask = _tarefa.FirstOrDefault(task => task.Id == id);
            if (existingTask != null)
            {
                existingTask.Descricao = updatedTask.Descricao;
                existingTask.Status = "C";
            }
        }

        public bool Excluir(int id)
        {
            var taskToRemove = _tarefa.FirstOrDefault(task => task.Id == id);
            if (taskToRemove != null)
            {
                _tarefa.Remove(taskToRemove);
                return true;
            }
            return false;
        }
    }
}
