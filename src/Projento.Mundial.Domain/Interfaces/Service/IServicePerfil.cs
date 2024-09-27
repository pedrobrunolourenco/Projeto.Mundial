using Projeto.Mundial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projento.Mundial.Domain.Interfaces.Service
{
    public interface IServicePerfil
    {
        Task<IEnumerable<Perfil>> ObterPerfis();
        Task<Perfil> IncluirPerfil(Perfil perfil);
    }
}
