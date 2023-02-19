using System.Collections.Generic;
using System.Threading.Tasks;
using TesteSysMap.src.dtos;
using TesteSysMap.src.modelos;

namespace TesteSysMap.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Interface Responsavvel por representar ações de CRUD de usuario</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary>

    public interface IUsuario
    {
        Task NovoUsuarioAsync(NovoUsuarioDTO usuario);
        Task AtualizarUsuarioAsync(AtualizarUsuarioDTO usuario);
        Task DeletarUsuarioAsync(int id);
        Task<List<UsuarioModelo>> PegarTodosUsuariosAsync();
        Task<UsuarioModelo> PegarUsuarioPeloIdAsync(int id);
        Task<UsuarioModelo> PegarUsuarioPeloEmailAsync(string email);
    }