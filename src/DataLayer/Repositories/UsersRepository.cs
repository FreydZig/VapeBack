using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly VapeContext _context;

        public UsersRepository(VapeContext context)
        {
            _context = context;
        }

        public async Task<Users> Create(Users user)
        {
            await _context
                .Users
                .AddAsync(user);

            await _context
                .SaveChangesAsync();

            return user;
        }

        public async Task<Users> Read(int userId)
        {
            var entity = await _context
                .Users
                .FirstOrDefaultAsync(u => u.UserId == userId);
            return entity;
        }
    }
}
