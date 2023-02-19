using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TesteSysMap.src.utilidades;

namespace TesteSysMap.src.modelos
{
    /// <summary>
    /// <para>Resumo: Classe responsavel pelo modelo do objeto usuario, representa tb_usuarios no banco de dados.</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>Versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary>

    [Table("tb_usuarios")]

    public class UsuarioModelo
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required]
        public int DataNascimento { get; set; }

        [Required, StringLength(30)]
        public string Senha { get; set; }

        public string Foto { get; set; }

        [Required]
        public TipoUsuario Tipo { get; set; }

        public List<TarefaModelo> MinhasTarefas { get; set; }

        #endregion
    }
}
