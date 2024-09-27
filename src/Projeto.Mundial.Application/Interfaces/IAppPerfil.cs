using Projeto.Mundial.Application.Models;

namespace Projeto.Mundial.Application.Interfaces
{
    public interface IAppPerfil
    {
        Task<PerfilModel> IncluirPerfil(PerfilModel perfil);
    }
}
