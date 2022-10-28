using DataLayer.Entities;

namespace Domain.Services.Interfaces
{
    public interface IProductsService
    {
        Task<Products> Add(Products products);
        Task<Products> Read(int id);
    }
}
