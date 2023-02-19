using System.ComponentModel.DataAnnotations;
using TesteSysMap.src.utilidades;

namespace TesteSysMap.src.dtos
{
    /// <summary>
    /// <para>Resumo: Classe espelho para criar um novo usuario</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary> 

    public class NovoUsuarioDTO
    {
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


        public NovoUsuarioDTO(string nome, string email, int dataNascimento, string senha, string foto, TipoUsuario tipo)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Senha = senha;
            Foto = foto;
            Tipo = tipo;
        }
    }

    /// <summary>
    /// <para>Resumo: Classe espelho para atualizar um usuario</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary> 

    public class AtualizarUsuarioDTO
    {
        [Required]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required, StringLength(30)]
        public string Senha { get; set; }

        public string Foto { get; set; }

        public AtualizarUsuarioDTO(int id, string email, string senha, string foto)
        {
            Id = id;
            Email = email;
            Senha = senha;
            Foto = foto;

        }
    }

}