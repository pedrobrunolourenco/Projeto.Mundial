using Microsoft.AspNetCore.Mvc;
using Projeto.Mundial.Application.Interfaces;
using Projeto.Mundial.Application.Models;

namespace Projeto.Mundial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
                _logger.LogError($"IncluirPerfil {ex.Message}");
                return BadRequest();
            }
        }


    }
}
