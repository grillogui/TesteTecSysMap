﻿using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TesteSysMap.src.servicos;
using TesteSysMap.src.dtos;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TesteSysMap.src.controladores
{
    [ApiController]
    [Route("api/Autenticacao")]
    [Produces("application/json")]
    public class AutenticacaoControlador : ControllerBase
    {
        #region Atributos

        private readonly IAutenticacao _servicos;

        #endregion


        #region Construtores

        public AutenticacaoControlador(IAutenticacao servicos)
        {
            _servicos = servicos;
        }

        #endregion


        #region Métodos

        /// <summary>
        /// Pegar Autorização
        /// </summary>
        /// <param name="autenticacao">AutenticarDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Exemplo de requisição:
        ///
        ///     POST /api/Autenticacao
        ///     {
        ///        "email": "gui.grillo@gmail.com",
        ///        "senha": "123456"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Retorna usuario criado</response>
        /// <response code="400">Erro na requisição</response>
        /// <response code="401">E-mail ou senha invalido</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(AutorizacaoDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AutenticarAsync([FromBody] AutenticarDTO autenticacao)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var autorizacao = await _servicos.PegarAutorizacaoAsync(autenticacao);
                return Ok(autorizacao);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        #endregion
    }
}