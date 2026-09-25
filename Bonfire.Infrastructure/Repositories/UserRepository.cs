using Bonfire.Application.Interfaces;
using Bonfire.Domain.Entities;
using Bonfire.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Bonfire.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BonfireDbContext _context;

        public UserRepository(BonfireDbContext context)
        {
            _context = context;
        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }        
}
