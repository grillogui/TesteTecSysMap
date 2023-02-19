using System.ComponentModel.DataAnnotations;
using TesteSysMap.src.utilidades;

namespace TesteSysMap.src.dtos
{
    /// <summary>
    /// <para>Resumo: Classe espelho para Autenticar um usuario</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary> 
    public class AutenticarDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Senha { get; set; }
        public AutenticarDTO(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }

    /// <summary>
    /// <para>Resumo: Classe espelho para Autorizar um usuario</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary> 
    public class AutorizacaoDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public TipoUsuario Tipo { get; set; }
        public string Token { get; set; }
        public AutorizacaoDTO(int id, string email, TipoUsuario tipo, string
        token)
        {
            Id = id;
            Email = email;
            Tipo = tipo;
            Token = token;
        }
    }
}