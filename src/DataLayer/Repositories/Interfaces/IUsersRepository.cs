using DataLayer.Entities;

namespace DataLayer.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<Users> Create(Users user);
        Task<Users> Read(int userId);
    }
}
