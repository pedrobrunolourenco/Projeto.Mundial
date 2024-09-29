using Projento.Mundial.Domain.DTO;
using Projento.Mundial.Domain.Interfaces.Repository;
using Projento.Mundial.Domain.Interfaces.Service;
using Projeto.Mundial.Domain.Entities;
using Projeto.Mundial.Domain.Extensions;

namespace Projento.Mundial.Domain.Services
{
    public class ServiceUsuario : IServiceUsuario
    {

        private readonly IUnitOfWork _unitOfWork;

        public ServiceUsuario(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Usuario> ObterUsuario(string nome, string senha)
        {
            var result = await _unitOfWork.RepositoryUsuario.Listar();
            return result.FirstOrDefault(x => x.Nome == nome && x.Senha == senha.Criptografar());
        }



        public async Task<List<UsuarioPerfilDto>> ObterUsuariosComPerfisAsync()
        {
            return await _unitOfWork.RepositoryUsuario.ObterUsuariosComPerfisAsync();
        }


        public async Task<Usuario> IncluirUsuario(Usuario usuario)
        {
            if (!usuario.Validar()) return usuario;
            var errosDominio = await ValidarRegrasDeDominio(usuario);
            if (errosDominio.ListaErros.Any()) return usuario;
            usuario.AtribuirSenha(usuario.Senha);
            await _unitOfWork.RepositoryUsuario.Adicionar(usuario);
            await _unitOfWork.Commit();
            return usuario;

        }

        private async Task<Usuario> ValidarRegrasDeDominio(Usuario usuario)
        {
            if (await VerificarSeIdJaExiste(usuario.Id)) usuario.ListaErros.Add($"O ID {usuario.Id} já existe.");
            if (!await VerificarSeOPerfilExiste(usuario.IdPerfil)) usuario.ListaErros.Add($"O Perfil {usuario.IdPerfil} não existe.");
            if (await VerificarSeNomeJaExiste(usuario.Nome)) usuario.ListaErros.Add($"O usuário {usuario.Nome} já existe.");
            if (await VerificarSeEmailJaExiste(usuario.Email)) usuario.ListaErros.Add($"O Email {usuario.Email} já existe.");
            return usuario;
        }

        private async Task<bool> VerificarSeOPerfilExiste(int idPerfil)
        {
            var result = await _unitOfWork.RepositoryPerfil.BuscarId(idPerfil);
            return result == null ? false : true;
        }


        private async Task<bool> VerificarSeIdJaExiste(int id)
        {
            var result = await _unitOfWork.RepositoryUsuario.BuscarId(id);
            return result == null ? false : true;
        }

        private async Task<bool> VerificarSeNomeJaExiste(string nome)
        {
            var result = await _unitOfWork.RepositoryUsuario.Listar();
            return result.Where(p => p.Nome.ToUpper() == nome.ToUpper()).Any();
        }

        private async Task<bool> VerificarSeEmailJaExiste(string email)
        {
            var result = await _unitOfWork.RepositoryUsuario.Listar();
            return result.Where(p => p.Email.ToUpper() == email.ToUpper()).Any();
        }

    }
}
