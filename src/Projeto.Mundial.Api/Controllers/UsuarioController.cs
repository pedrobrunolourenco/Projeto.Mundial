using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Projeto.Mundial.Application.Interfaces;
using Projeto.Mundial.Application.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Projeto.Mundial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : BasicController
    {

        private IAppUsuario _appUsuario;
        private ILogger _logger;
        private IConfiguration _config;

        public UsuarioController(IAppUsuario appUsuario,
                                 IConfiguration configuration,
                                 ILogger<PerfilController> logger)
        {
            _appUsuario = appUsuario;
            _logger = logger;
        }

        [HttpPost]
        [Route("Autenticar")]
        [AllowAnonymous]
        public async Task<IActionResult> Logar(User login)
        {
            try
            {
                var user_ = AutenticacaoUsuario(login);
                if (user_.Usuario == "Mundial")
                {
                    var token = GerarToken(login);
                    var response = new { Token = token };
                    return RetornoRequest(response);
                }
                else
                {
                    var result = await _appUsuario.ObterUsuario(login.Usuario, login.Senha);
                    if(result != null)
                    {
                        var token = GerarToken(login);
                        var response = new { Token = token };
                        return RetornoRequest(response);
                    }
                }
                var erro = new List<string> { "Usuáro não encontrado." };
                return RetornoRequest(user_.Usuario, erro);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Logar {ex.Message}");
                return BadRequest();
            }
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



        private User AutenticacaoUsuario(User user)
        {
            var _user = new User();
            if (user.Usuario == "Adm" && user.Senha == "12345")
            {
                _user.Usuario = "Mundial";
            }
            return _user;
        }

        private string GerarToken(User users)
        {
            var chave = "App-Teste-Pedro-Bruno";
            var chaveSegura = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chave));
            var credencial = new SigningCredentials(chaveSegura, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(null,
                                             expires: DateTime.Now.AddMinutes(200),
                                             signingCredentials: credencial
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
