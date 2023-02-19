using System.ComponentModel.DataAnnotations;

namespace TesteSysMap.src.dtos
{
    /// <summary>
    /// <para>Resumo: Classe espelho para criar uma nova tarefa</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary> 

    public class NovaTarefaDTO
    {
        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Data { get; set; }

        [Required]
        public string EmailCriador { get; set; }

        public NovaTarefaDTO(string descricao, string data, string emailCriador)
        {
            Descricao = descricao;
            Data = data;
            EmailCriador = emailCriador;
        }
    }

    /// <summary>
    /// <para>Resumo: Classe espelho para atualizar uma tarefa</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary> 
    /// 

    public class AtualizarTarefaDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Data { get; set; }

        public AtualizarTarefaDTO(int id, string descricao, string data)
        {
            Id = id;
            Descricao = descricao;
            Data = data;
        }
    }
}
