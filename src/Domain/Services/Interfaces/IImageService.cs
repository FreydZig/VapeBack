using Microsoft.AspNetCore.Http;

namespace Domain.Services.Interfaces
{
    public interface IImageService
    {
        Task<string> Create(IFormFile file);
    }
}
