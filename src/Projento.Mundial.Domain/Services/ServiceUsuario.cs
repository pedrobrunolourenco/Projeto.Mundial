using Projento.Mundial.Domain.Interfaces.Repository;
using Projento.Mundial.Domain.Interfaces.Service;
using Projeto.Mundial.Domain.Entities;

namespace Projento.Mundial.Domain.Services
{
    public class ServiceUsuario : IServiceUsuario
    {

        private readonly IRepositoryUsuario _repositoryUsuario;
        private readonly IRepositoryPerfil _repositoryPerfil;

        public ServiceUsuario(IRepositoryUsuario repositoryUsuario,
                              IRepositoryPerfil repositoryPerfil)
        {
            _repositoryUsuario = repositoryUsuario;
            _repositoryPerfil = repositoryPerfil;
        }

        public async Task<IEnumerable<Usuario>> ObterUsuarios()
        {
            return await _repositoryUsuario.Listar();
        }

        public async Task<Usuario> IncluirUsuario(Usuario usuario)
        {
            if (!usuario.Validar()) return usuario;
            var errosDominio = await ValidarRegrasDeDominio(usuario);
            if (errosDominio.ListaErros.Any()) return usuario;
            await _repositoryUsuario.Adicionar(usuario);
            await _repositoryUsuario.Salvar();
            return usuario;

        }

        private async Task<Usuario> ValidarRegrasDeDominio(Usuario usuario)
        {
            if (await VerificarSeIdJaExiste(usuario.Id)) usuario.ListaErros.Add($"O ID {usuario.Id} já existe.");
            if (!await VerificarSeOPerfilExiste(usuario.IdPerfil)) usuario.ListaErros.Add($"O ID {usuario.Id} não existe.");
            if (await VerificarSeNomeJaExiste(usuario.Nome)) usuario.ListaErros.Add($"O usuário {usuario.Nome} já existe.");
            if (await VerificarSeEmailJaExiste(usuario.Email)) usuario.ListaErros.Add($"O Email {usuario.Email} já existe.");
            return usuario;
        }

        private async Task<bool> VerificarSeOPerfilExiste(int idPerfil)
        {
            var result = await _repositoryPerfil.BuscarId(idPerfil);
            return result == null ? false : true;
        }


        private async Task<bool> VerificarSeIdJaExiste(int id)
        {
            var result = await _repositoryUsuario.BuscarId(id);
            return result == null ? false : true;
        }

        private async Task<bool> VerificarSeNomeJaExiste(string nome)
        {
            var result = await _repositoryUsuario.Listar();
            return result.Where(p => p.Nome.ToUpper() == nome.ToUpper()).Any();
        }

        private async Task<bool> VerificarSeEmailJaExiste(string email)
        {
            var result = await _repositoryUsuario.Listar();
            return result.Where(p => p.Email.ToUpper() == email.ToUpper()).Any();
        }


    }
}
