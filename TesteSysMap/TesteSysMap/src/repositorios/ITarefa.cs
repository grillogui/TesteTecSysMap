using System.Collections.Generic;
using System.Threading.Tasks;
using TesteSysMap.src.dtos;
using TesteSysMap.src.modelos;

namespace TesteSysMap.src.repositorios
{
    /// <summary>
    /// <para>Resumo: Interface Responsavvel por representar ações de CRUD de tarefas</para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary>

    public interface ITarefa
    {
        Task NovaTarefaAsync(NovaTarefaDTO tarefa);
        Task AtualizarTarefaAsync(AtualizarTarefaDTO tarefa);
        Task DeletarTarefaAsync(int id);
        Task<TarefaModelo> PegarTarefaPeloIdAsync(int id);
        Task<List<TarefaModelo>> PegarTodasTarefasAsync();

    }
}