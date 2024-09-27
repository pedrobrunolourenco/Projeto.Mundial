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

            CreateMap<UsuarioModel, Usuario>()
                    .ConstructUsing(u => new Usuario(u.Id, u.IdPerfil, u.Nome, u.Email, u.Senha));

        }
    }
}
