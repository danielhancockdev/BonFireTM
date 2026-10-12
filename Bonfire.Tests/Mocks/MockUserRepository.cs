using Bonfire.Application.Interfaces;
using Bonfire.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bonfire.Tests.Mocks
{
    public class MockUserRepository : IUserRepository
    {

        public User? UserToReturn { get; set; }

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByEmailAsync(string email)
        {
            return Task.FromResult(UserToReturn);
        }
    }
}
