using AutoMapper;
using Projeto.Mundial.Application.Models;
using Projeto.Mundial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Mundial.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Perfil, PerfilModel>();
            CreateMap<Usuario, UsuarioModel>();
            CreateMap<Usuario, UsuarioResult>();

        }
    }
}
