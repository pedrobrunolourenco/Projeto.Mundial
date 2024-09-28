using Projeto.Mundial.Application.Models;
using Projeto.Mundial.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Mundial.Application.Interfaces
{
    public interface IAppUsuario
    {
        Task<IEnumerable<UsuarioModel>> ObterUsuarios();
        Task<UsuarioResult> IncluirUsuario(UsuarioModel usuario);

    }
}
