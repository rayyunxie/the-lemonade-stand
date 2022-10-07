﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using tls.api.Errors;
using tls.api.Orders;

namespace tls.api.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IOrderRepository> _orderRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(repositoryContext));
        }

        public IOrderRepository Order => _orderRepository.Value;

        public Task Save()
        {
            return _repositoryContext.SaveChangesAsync();
        }

        public async Task SaveAndCheckError(RepositoryError repositoryError)
        {
            try
            {
                await _repositoryContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex) when (
                repositoryError == RepositoryError.ConstraintViolation &&
                ex.InnerException is SqlException sqlException &&
                sqlException.Number == 547)
            {
                throw new ConstraintViolationRepositoryException();
            }
        }
    }
}
