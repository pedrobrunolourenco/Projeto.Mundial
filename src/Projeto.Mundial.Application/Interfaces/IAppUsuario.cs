using Projento.Mundial.Domain.DTO;
using Projeto.Mundial.Application.Models;

namespace Projeto.Mundial.Application.Interfaces
{
    public interface IAppUsuario
    {
        Task<IEnumerable<UsuarioPerfilDto>> ObterUsuarios();
        Task<UsuarioResult> IncluirUsuario(UsuarioModel usuario);

    }
}
