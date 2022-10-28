using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Domain.Services.Interfaces;

namespace Domain.Services
{
    public class UserService : IUserService
    {

        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Users> AddUser(Users users)
        {
            var entity = await _usersRepository.Create(users);
            return entity;
        }

        public async Task<Users> GetUser(int userId)
        {
            var entity = await _usersRepository.Read(userId);
            return entity;
        }
    }
}
