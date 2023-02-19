using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteSysMap.src.modelos
{
    /// <summary>
    /// <para>Resumo: Classe responsavel pelo modelo do objeto Tarefa, representa tb_tarefas no banco de dados.</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary>
    /// 
    [Table("tb_postagens")]
    public class TarefaModelo
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Data { get; set; }

        [ForeignKey("fk_usuario")]
        public UsuarioModelo Criador { get; set; }


        #endregion
    }
}
