using Projento.Mundial.Domain.Interfaces.Repository;
using Projento.Mundial.Domain.Interfaces.Service;
using Projeto.Mundial.Domain.Entities;

namespace Projento.Mundial.Domain.Services
{
    public class ServicePerfil : IServicePerfil
    {

        private readonly IRepositoryPerfil _repositoryPerfil;

        public ServicePerfil(IRepositoryPerfil repositoryPerfil)
        {
            _repositoryPerfil = repositoryPerfil;      
        }

        public async Task<IEnumerable<Perfil>> ObterPerfis()
        {
            return await _repositoryPerfil.Listar();
        }

        public async Task<Perfil> IncluirPerfil(Perfil perfil)
        {
            if (!perfil.Validar()) return perfil;
            await _repositoryPerfil.Adicionar(perfil);
            await _repositoryPerfil.Salvar();
            return perfil;
        }

    }
}
