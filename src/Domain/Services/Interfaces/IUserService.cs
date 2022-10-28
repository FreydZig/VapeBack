using DataLayer.Entities;

namespace Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<Users> AddUser(Users users);

        Task<Users> GetUser(int userId);
    }
}
