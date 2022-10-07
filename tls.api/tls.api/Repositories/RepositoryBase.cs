using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace tls.api.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext _repositoryContext;

        public RepositoryBase(RepositoryContext repositoryContext) =>
            _repositoryContext = repositoryContext;

        public IQueryable<T> GetAll() =>
            _repositoryContext.Set<T>();

        public IQueryable<T> GetAllAsTracking() =>
            _repositoryContext.Set<T>().AsTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            _repositoryContext.Set<T>().Where(expression);

        public void Create(T entity) => _repositoryContext.Set<T>().Add(entity);

        public void Delete(T entity) => _repositoryContext.Set<T>().Remove(entity);
    }
}