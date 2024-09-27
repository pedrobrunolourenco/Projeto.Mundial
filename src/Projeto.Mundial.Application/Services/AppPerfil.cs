using AutoMapper;
using Projento.Mundial.Domain.Interfaces.Service;
using Projeto.Mundial.Application.Interfaces;
using Projeto.Mundial.Application.Models;
using Projeto.Mundial.Domain.Entities;

namespace Projeto.Mundial.Application.Services
{
    public class AppPerfil : IAppPerfil
    {
        private readonly IMapper _mapper;
        private readonly IServicePerfil _servicePerfil;

        public AppPerfil(IMapper mapper,
                         IServicePerfil servicePerfil)
        {
            _mapper = mapper;
            _servicePerfil = servicePerfil;
        }

        public async Task<IEnumerable<PerfilModel>> ObterPerfis()
        {
            return _mapper.Map<IEnumerable<PerfilModel>>(await _servicePerfil.ObterPerfis());
        }

        public async Task<PerfilModel> IncluirPerfil(PerfilModel perfil)
        {
            return _mapper.Map<PerfilModel>(await _servicePerfil.IncluirPerfil(_mapper.Map<Perfil>(perfil)));
        }

    }
}
