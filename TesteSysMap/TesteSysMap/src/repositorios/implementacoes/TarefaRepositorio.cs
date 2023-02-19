using System.Collections.Generic;
using System.Linq;
using TesteSysMap.src.contexto;
using TesteSysMap.src.dtos;
using TesteSysMap.src.modelos;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TesteSysMap.src.repositorios.implementacoes
{
    /// <summary>
    /// <para>Resumo: Implementação de Métodos e Construtores para a classe usuarios </para>
    /// <para>Criado por: Guilherme Grillo</para>
    /// <para>versão: 1.0</para>
    /// <para>Data: 18/02/2023</para>
    /// </summary>

    public class TarefaRepositorio : ITarefa
    {
        #region Atributos
        private readonly TesteSysMapContexto _contexto;
        #endregion Atributos

        #region Construtores
        public TarefaRepositorio(TesteSysMapContexto contexto)
        {
            _contexto = contexto;
        }
        #endregion Construtores


        #region Métodos
        /// <summary>
        /// <para>Resumo: Método assíncrono para criar uma tarefa</para>
        /// </summary>
        /// <param name="tarefa">NovaTarefaDTO</param>
        public async Task NovaTarefaAsync(NovaTarefaDTO tarefa)
        {
            await _contexto.Tarefas.AddAsync(new TarefaModelo
            {
                Descricao = tarefa.Descricao,
                Data = tarefa.Data,
                Criador = _contexto.Usuarios.FirstOrDefault(
                u => u.Email == tarefa.EmailCriador)
            });
            await _contexto.SaveChangesAsync();
        }



        /// <summary>
        /// <para>Resumo: Método assíncrono para atualizar uma tarefa</para>
        /// </summary>
        /// <param name="tarefa">AtualizarTarefaDTO</param>
        public async Task AtualizarTarefaAsync(AtualizarTarefaDTO tarefa)
        {
            var tarefaExistente = await PegarTarefaPeloIdAsync(tarefa.Id);
            tarefaExistente.Descricao = tarefa.Descricao;
            tarefaExistente.Data = tarefa.Data;
            await _contexto.SaveChangesAsync();
        }


        /// <summary>
        /// <para>Resumo: Método assíncrono para deletar uma tarefa</para>
        /// </summary>
        /// <param name="id">Id da tarefa</param>
        public async Task DeletarTarefaAsync(int id)
        {
            _contexto.Tarefas.Remove(await PegarTarefaPeloIdAsync(id));
            await _contexto.SaveChangesAsync();
        }


        /// <summary>
        /// <para>Resumo: Método assíncrono para pegar uma tarefa pelo Id</para>
        /// </summary>
        /// <param name="id">Id da tarefa</param>
        /// <return>TarefaModelo</return>
        public async Task<TarefaModelo> PegarTarefaPeloIdAsync(int id)
        {
            return await _contexto.Tarefas.Include(t => t.Criador).FirstOrDefaultAsync(t => t.Id == id);
        }



        /// <summary>
        /// <para>Resumo: Método assíncrono para listar todas tarefas</para>
        /// </summary>
        /// <return>Lista TarefaModelo></return>
        public async Task<List<TarefaModelo>> PegarTodasTarefasAsync()
        {
            return await _contexto.Tarefas.ToListAsync();
        }
        #endregion Métodos
    }
}