using Projento.Mundial.Domain.DTO;
using Projeto.Mundial.Domain.Entities;

namespace Projento.Mundial.Domain.Interfaces.Repository
{
    public interface IRepositoryUsuario : IRepository<Usuario>
    {
        Task<List<UsuarioPerfilDto>> ObterUsuariosComPerfisAsync();
    }

    
}
