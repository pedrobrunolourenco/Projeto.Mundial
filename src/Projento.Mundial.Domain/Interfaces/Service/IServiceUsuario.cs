using Projeto.Mundial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projento.Mundial.Domain.Interfaces.Service
{
    public interface IServiceUsuario
    {
        Task<IEnumerable<Usuario>> ObterUsuarios();
        Task<Usuario> IncluirUsuario(Usuario usuario);

    }
}
