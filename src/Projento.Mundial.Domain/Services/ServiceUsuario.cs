using Projento.Mundial.Domain.Interfaces.Repository;
using Projento.Mundial.Domain.Interfaces.Service;
using Projeto.Mundial.Domain.Entities;

namespace Projento.Mundial.Domain.Services
{
    public class ServiceUsuario : IServiceUsuario
    {

        private readonly IRepositoryUsuario _repositoryUsuario;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario)
        {
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<IEnumerable<Usuario>> ObterUsuarios()
        {
            return await _repositoryUsuario.Listar();
        }

        public async Task<Usuario> IncluirUsuario(Usuario usuario)
        {
            if (!usuario.Validar()) return usuario;
            // var errosDominio = await ValidarRegrasDeDominio(perfil);
            // if (errosDominio.ListaErros.Any()) return perfil;
            await _repositoryUsuario.Adicionar(usuario);
            await _repositoryUsuario.Salvar();
            return usuario;

        }

    }
}
