using Projento.Mundial.Domain.DTO;
using Projeto.Mundial.Domain.Entities;

namespace Projento.Mundial.Domain.Interfaces.Service
{
    public interface IServiceUsuario
    {
        Task<Usuario> IncluirUsuario(Usuario usuario);
        Task<List<UsuarioPerfilDto>> ObterUsuariosComPerfisAsync();
        Task<Usuario?> ObterUsuario(string nome, string senha);


    }
}
