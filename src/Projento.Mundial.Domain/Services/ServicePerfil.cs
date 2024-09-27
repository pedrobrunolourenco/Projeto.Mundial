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
            var errosDominio = await ValidarRegrasDeDominio(perfil);
            if (errosDominio.ListaErros.Any()) return perfil;
            await _repositoryPerfil.Adicionar(perfil);
            await _repositoryPerfil.Salvar();
            return perfil;
        }

        private async Task<Perfil> ValidarRegrasDeDominio(Perfil perfil)
        {
            if (await VerificarSeIdJaExiste(perfil.IdPerfil)) perfil.ListaErros.Add($"O ID {perfil.IdPerfil} já existe.");
            if (await VerificarSeNomeJaExiste(perfil.Nome)) perfil.ListaErros.Add($"O perfil {perfil.Nome} já existe.");
            return perfil;
        }

        private async Task<bool> VerificarSeIdJaExiste(int id)
        {
            var result = await _repositoryPerfil.BuscarId(id);
            return result == null ? true : false;
        }

        private async Task<bool> VerificarSeNomeJaExiste(string nome)
        {
            var result = await _repositoryPerfil.Listar();
            var retorno = result.Where(p => p.Nome == nome).Any();
            return retorno;
        }


    }
}
