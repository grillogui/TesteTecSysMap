using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TesteSysMap.src.dtos;
using TesteSysMap.src.modelos;
using TesteSysMap.src.repositorios;
using TesteSysMap.src.servicos;

namespace TesteSysMap.src.controladores
{
    [ApiController]
    [Route("api/Usuarios")]
    [Produces("application/json")]
    public class UsuarioControlador : ControllerBase
    {
        #region Atributos

        private readonly IUsuario _repositorio;
        private readonly IAutenticacao _servico;


        #endregion

        #region Construtores

        public UsuarioControlador(IUsuario repositorio, IAutenticacao servico)
        {
            _repositorio = repositorio;
            _servico = servico;
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Criar novo Usuario
        /// </summary>
        /// <param name="usuario">NovoUsuarioDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/Usuarios
        ///     {
        ///        "nome": "Guilherme Grillo",
        ///        "email": "gui.grillo@email.com",
        ///        "dataNascimento": "05052000"
        ///        "senha": "123456",
        ///        "foto": "URLFOTO",
        ///        "tipo": "NORMAL"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna usuario criado</response>
        /// <response code="400">Erro na requisição</response>
        /// <response code="401">E-mail ja cadastrado</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UsuarioModelo))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> NovoUsuarioAsync([FromBody] NovoUsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _servico.CriarUsuarioSemDuplicarAsync(usuario);
                return Created($"api/Usuarios/email/{usuario.Email}", usuario);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }


        /// <summary>
        /// Atualizar Usuario
        /// </summary>
        /// <param name="usuario">AtualizarUsuarioDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     PUT /api/Usuarios
        ///     {
        ///        "id": 1,    
        ///        "email": "gui.grillo@SysMap.com"
        ///        "senha": "134652",
        ///        "foto": "URLFOTO"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Retorna usuario atualizado</response>
        /// <response code="400">Erro na requisição</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [HttpPut]
        [Authorize(Roles = "NORMAL,ADMINISTRADOR")]
        public async Task<ActionResult> AtualizarUsuarioAsync([FromBody] AtualizarUsuarioDTO usuario)
        {
            if (!ModelState.IsValid) return BadRequest();

            usuario.Senha = _servico.CodificarSenha(usuario.Senha);

            await _repositorio.AtualizarUsuarioAsync(usuario);
            return Ok(usuario);
        }


        /// <summary>
        /// Deletar usuario pelo Id
        /// </summary>
        /// <param name="idUsuario">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="204">Usuario deletado</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpDelete("deletar/{idUsuario}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<ActionResult> DeletarUsuarioAsync([FromRoute] int idUsuario)
        {
            await _repositorio.DeletarUsuarioAsync(idUsuario);
            return NoContent();
        }


        /// <summary>
        /// Pegar todos os usuarios
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna os usuarios</response>
        /// <response code="204">Não existem usuarios</response>
        [HttpGet("lista")]
        [Authorize]
        public async Task<ActionResult> PegarTodasPostagensAsync()
        {
            var lista = await _repositorio.PegarTodosUsuariosAsync();

            if (lista.Count < 1) return NoContent();

            return Ok(lista);
        }

        /// <summary>
        /// Pegar usuario pelo Id
        /// </summary>
        /// <param name="idUsuario">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna o usuario</response>
        /// <response code="404">Usuario não existente</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioModelo))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("id/{idUsuario}")]
        [Authorize(Roles = "ADMINISTRADOR")]
        public async Task<ActionResult> PegarUsuarioPeloIdAsync([FromRoute] int idUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloIdAsync(idUsuario);

            if (usuario == null) return NotFound();

            return Ok(usuario);
        }


        /// <summary>
        /// Pegar usuario pelo Email
        /// </summary>
        /// <param name="emailUsuario">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna o usuario</response>
        /// <response code="404">Email não existente</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UsuarioModelo))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("email/{emailUsuario}")]
        [Authorize(Roles = "NORMAL,ADMINISTRADOR")]
        public async Task<ActionResult> PegarUsuarioPeloEmailAsync([FromRoute] string emailUsuario)
        {
            var usuario = await _repositorio.PegarUsuarioPeloEmailAsync(emailUsuario);

            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        #endregion



    }
}