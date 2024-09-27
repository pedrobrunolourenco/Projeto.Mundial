using Projeto.Mundial.Application.Models;

namespace Projeto.Mundial.Application.Interfaces
{
    public interface IAppPerfil
    {
        Task<IEnumerable<PerfilModel>> ObterPerfis();
        Task<PerfilModel> IncluirPerfil(PerfilModel perfil);
    }
}
