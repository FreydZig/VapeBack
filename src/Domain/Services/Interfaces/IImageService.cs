using Microsoft.AspNetCore.Http;

namespace Domain.Services.Interfaces
{
    public interface IImageService
    {
        string Create(IFormFile file);
    }
}
