using Projento.Mundial.Domain.Interfaces.Repository;

namespace Projeto.Mundial.Data.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _context;
        private IRepositoryPerfil _repositoryPerfil;
        private IRepositoryUsuario _repositoryUsuario;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public IRepositoryPerfil RepositoryPerfil
        {
            get { return _repositoryPerfil ??= new RepositoryPerfil(_context); }
        }

        public IRepositoryUsuario RepositoryUsuario
        {
            get { return _repositoryUsuario ??= new RepositoryUsuario(_context); }
        }


        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }


        public Task Rollback()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
