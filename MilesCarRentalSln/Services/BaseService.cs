﻿using Repositories;

namespace Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task InsertAsync(T entity)
        {
            await _repository.InsertAsync(entity);
        }

        public async Task UpdateAsync(string id, T entity)
        {
            await _repository.UpdateAsync(id, entity);
        }

        public async Task DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}