using Projento.Mundial.Domain.Interfaces.Repository;
using Projeto.Mundial.Domain.Entities;

namespace Projeto.Mundial.Data.Repositories
{
    public class RepositoryUsuario: Repository<Usuario>, IRepositoryUsuario
    {
        public RepositoryUsuario(DataContext context) : base(context)
        {
            
        }
    }
}
