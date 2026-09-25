using Bonfire.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);

        Task AddAsync(User user);
    }
}
