using System.Threading.Tasks;
using TesteSysMap.src.dtos;
using TesteSysMap.src.modelos;

namespace TesteSysMap.src.servicos
{
    /// <summary>
    /// <para>Resumo: Interface Responsavvel por representar ações usadas na autenticacao do usuario</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary>
    public interface IAutenticacao
    {
        string CodificarSenha(string senha);
        Task CriarUsuarioSemDuplicarAsync(NovoUsuarioDTO usuario);
        string GerarToken(UsuarioModelo usuario);
        Task<AutorizacaoDTO> PegarAutorizacaoAsync(AutenticarDTO autenticacao);
    }
}
