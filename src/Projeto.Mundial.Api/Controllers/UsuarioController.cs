using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Mundial.Application.Interfaces;
using Projeto.Mundial.Application.Models;

namespace Projeto.Mundial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BasicController
    {

        private IAppUsuario _appUsuario;
        private ILogger _logger;

        public UsuarioController(IAppUsuario appUsuario,
                                 ILogger<PerfilController> logger)
        {
            _appUsuario = appUsuario;
            _logger = logger;
        }

        [HttpGet]
        [Route("ObterUsuarios")]
        public async Task<IActionResult> ObterUsuarios()
        {
            try
            {
                var result = await _appUsuario.ObterUsuarios();
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterUsuarios => {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("IncluirUsuario")]
        public async Task<IActionResult> IncluirUsuario([FromBody] UsuarioModel model)
        {
            try
            {
                var usuario = await _appUsuario.IncluirUsuario(model);
                return RetornoRequest(usuario, usuario.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IncluirUsuario => {ex.Message}");
                return BadRequest();
            }
        }


    }
}
