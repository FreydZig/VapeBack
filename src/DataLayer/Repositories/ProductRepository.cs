using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;

namespace DataLayer.Repositories
{
    public class ProductRepository : IProductsRepository
    {
        public Task<Products> Create(Products products)
        {
            throw new NotImplementedException();
        }

        public Task<Products> Read(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
