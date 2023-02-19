using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TesteSysMap.src.dtos;
using TesteSysMap.src.modelos;
using TesteSysMap.src.repositorios;

namespace TesteSysMap.src.controladores
{
    [ApiController]
    [Route("api/Tarefas")]
    [Produces("application/json")]
    public class TarefaControlador : ControllerBase
    {
        #region Atributos

        private readonly ITarefa _repositorio;

        #endregion


        #region Construtores

        public TarefaControlador(ITarefa repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Criar nova tarefa
        /// </summary>
        /// <param name="tarefa">NovaTarefaDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/Usuarios
        ///     {
        ///        "descrição": "fazer o teste da SysMap",
        ///        "data": "18/02/2023"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna tarefa criada</response>
        /// <response code="400">Erro na requisição</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TarefaModelo))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> NovaTarefaAsync([FromBody] NovaTarefaDTO tarefa)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repositorio.NovaTarefaAsync(tarefa);
            return Created($"api/Tarefas", tarefa);
        }


        /// <summary>
        /// Atualizar tarefa
        /// </summary>
        /// <param name="tarefa">AtualizarTarefaDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /api/Usuarios
        ///     {
        ///        "descrição": "entrevista SysMap",
        ///        "data": "22/02/2023"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna tarefa atualizada</response>
        /// <response code="400">Erro na requisição</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> AtualizarTarefaAsync([FromBody] AtualizarTarefaDTO tarefa)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repositorio.AtualizarTarefaAsync(tarefa);

            return Ok(tarefa);
        }


        /// <summary>
        /// Deletar tarefa pelo Id
        /// </summary>
        /// <param name="idTarefa">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Tarefa deletada</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("deletar/{idTarefa}")]
        [Authorize]
        public async Task<ActionResult> DeletarTarefaAsync([FromRoute] int idTarefa)
        {
            await _repositorio.DeletarTarefaAsync(idTarefa);
            return NoContent();
        }


        /// <summary>
        /// Pegar tarefa pelo Id
        /// </summary>
        /// <param name="idTarefa">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna a tarefa</response>
        /// <response code="404">Tarefa não existente</response>   
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TarefaModelo))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id/{idTarefa}")]
        [Authorize]
        public async Task<ActionResult> PegarTarefaPeloIdAsync([FromRoute] int idTarefa)
        {
            var tarefa = await _repositorio.PegarTarefaPeloIdAsync(idTarefa);

            if (tarefa == null) return NotFound();

            return Ok(tarefa);
        }


        /// <summary>
        /// Pegar todas as tarefas
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna as tarefas</response>
        /// <response code="204">Não existem tarefas</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TarefaModelo))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("lista")]
        [Authorize]
        public async Task<ActionResult> PegarTodaTarefasAsync()
        {
            var lista = await _repositorio.PegarTodasTarefasAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        #endregion
    }
}