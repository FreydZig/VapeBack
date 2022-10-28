using DataLayer.Entities;

namespace DataLayer.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<Products> Create(Products products);
        Task<Products> Read(int productId);
    }
}
