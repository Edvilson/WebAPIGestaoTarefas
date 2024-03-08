using System.ComponentModel.DataAnnotations;

namespace WebAPIGestaoTarefas.Model
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public required string Descricao { get; set; }

        public string Status { get; set; } = "P"; // 'P' por padrão, 'C' para concluído

        public static int NextId { get; set; } = 1;

    }
}
