﻿namespace LoginForm.Contracts
{
    public interface IGenericRepository<T> where T : class
    {

        Task<T?> GetAsync(int? ID);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
        Task UpdateAsync(T entity);

    }
}
