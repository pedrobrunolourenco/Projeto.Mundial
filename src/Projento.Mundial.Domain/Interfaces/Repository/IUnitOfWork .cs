namespace Projento.Mundial.Domain.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IRepositoryPerfil RepositoryPerfil { get; }
        IRepositoryUsuario RepositoryUsuario { get; }
        Task Commit();
        Task Rollback();
    }
}
