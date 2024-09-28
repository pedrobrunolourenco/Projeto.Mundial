using Microsoft.EntityFrameworkCore;
using Projento.Mundial.Domain.DTO;
using Projento.Mundial.Domain.Interfaces.Repository;
using Projeto.Mundial.Domain.Entities;

namespace Projeto.Mundial.Data.Repositories
{
    public class RepositoryUsuario: Repository<Usuario>, IRepositoryUsuario
    {
        private readonly DataContext _context;

        public RepositoryUsuario(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<UsuarioPerfilDto>> ObterUsuariosComPerfisAsync()
        {
            var usuariosComPerfis = await (from u in _context.Usuario
                                           join p in _context.Perfil on u.IdPerfil equals p.IdPerfil
                                           select new UsuarioPerfilDto
                                           {
                                               CodigoUsuario = u.Id,
                                               NomeUsuario = u.Nome,
                                               NomePerfil = p.Nome
                                           }).ToListAsync();

            return usuariosComPerfis;
        }

    }

}

