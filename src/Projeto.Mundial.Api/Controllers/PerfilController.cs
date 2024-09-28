using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto.Mundial.Application.Interfaces;
using Projeto.Mundial.Application.Models;

namespace Projeto.Mundial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PerfilController : BasicController
    {

        private IAppPerfil _appPerfil;
        private ILogger _logger;

        public PerfilController(IAppPerfil appPerfil,
                                ILogger<PerfilController> logger)
        {
            _appPerfil = appPerfil;
            _logger = logger;
        }

        [HttpGet]
        [Route("ObterPerfis")]
        public async Task<IActionResult> ObterPerfis()
        {
            try
            {
                var result = await _appPerfil.ObterPerfis();
                return RetornoRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ObterPerfis => {ex.Message}");
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("IncluirPerfil")]
        public async Task<IActionResult> IncluirPerfil([FromBody] PerfilModel model)
        {
            try
            {
                var perfil = await _appPerfil.IncluirPerfil(model);
                return RetornoRequest(perfil, perfil.ListaErros);
            }
            catch (Exception ex)
            {
                _logger.LogError($"IncluirPerfil => {ex.Message}");
                return BadRequest();
            }
        }


    }
}
