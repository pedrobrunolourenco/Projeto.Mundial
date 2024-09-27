using AutoMapper;
using Projento.Mundial.Domain.Interfaces.Service;
using Projeto.Mundial.Application.Interfaces;
using Projeto.Mundial.Application.Models;
using Projeto.Mundial.Domain.Entities;

namespace Projeto.Mundial.Application.Services
{
    public class AppUsuario : IAppUsuario
    {

        private readonly IMapper _mapper;
        private readonly IServiceUsuario _serviceUsuario;

        public AppUsuario(IMapper mapper,
                         IServiceUsuario serviceUsuario)
        {
            _mapper = mapper;
            _serviceUsuario = serviceUsuario;
        }


        public async Task<IEnumerable<UsuarioModel>> ObterUsuarios()
        {
            return _mapper.Map<IEnumerable<UsuarioModel>>(await _serviceUsuario.ObterUsuarios());
        }

        public async Task<UsuarioModel> IncluirUsuario(UsuarioModel usuario)
        {
            return _mapper.Map<UsuarioModel>(await _serviceUsuario.IncluirUsuario(_mapper.Map<Usuario>(usuario)));
        }

     
    }
}
