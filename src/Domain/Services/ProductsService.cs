using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Domain.Expextions;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Products> Add(Products products)
        {
            string? messge = null;
            if (products == null) messge = "Products is null! 13";
            if (messge != null) throw new ProductsExeption(messge);

            var answer = await _productsRepository.Create(products);

            return answer;
        }

        public Task<Products> Read(int id)
        {
            throw new NotImplementedException();
        }
    }
}
