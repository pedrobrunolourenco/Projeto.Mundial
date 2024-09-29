using Projento.Mundial.Domain.Interfaces.Repository;
using Projento.Mundial.Domain.Interfaces.Service;
using Projeto.Mundial.Domain.Entities;

namespace Projento.Mundial.Domain.Services
{
    public class ServicePerfil : IServicePerfil
    {

        private readonly IUnitOfWork _unitOfWork;

        public ServicePerfil(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Perfil>> ObterPerfis()
        {
            return await _unitOfWork.RepositoryPerfil.Listar();
        }

        public async Task<Perfil> IncluirPerfil(Perfil perfil)
        {
            if (!perfil.Validar()) return perfil;
            var errosDominio = await ValidarRegrasDeDominio(perfil);
            if (errosDominio.ListaErros.Any()) return perfil;
            await _unitOfWork.RepositoryPerfil.Adicionar(perfil);
            await _unitOfWork.Commit();
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
            var result = await _unitOfWork.RepositoryPerfil.BuscarId(id);
            return result == null ? false : true;
        }

        private async Task<bool> VerificarSeNomeJaExiste(string nome)
        {
            var result = await _unitOfWork.RepositoryPerfil.Listar();
            return result.Where(p => p.Nome.ToUpper() == nome.ToUpper()).Any();
        }


    }
}
