using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class ProductRepository : IProductsRepository
    {

        private readonly VapeContext _context;

        public ProductRepository(VapeContext context)
        {
            _context = context;
        }

        public async Task<Products> Create(Products products)
        {
            if (products == null)
            {
                throw new Exception("Product is incorrect!");
            }
            if (products.Image == null)
            {
                throw new Exception("Image is incorrect!");
            }
            await _context.Products.AddAsync(products);
            await _context.SaveChangesAsync();

            return products;
        }

        public Task<Products> Read(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
