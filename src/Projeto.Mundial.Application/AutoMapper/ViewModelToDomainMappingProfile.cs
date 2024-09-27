using AutoMapper;
using Projeto.Mundial.Application.Models;
using Projeto.Mundial.Domain.Entities;

namespace Projeto.Mundial.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PerfilModel, Perfil>()
                    .ConstructUsing(p => new Perfil(p.IdPerfil, p.Nome));

        }
    }
}
