using Bonfire.Application.Interfaces;

namespace Bonfire.Tests.Mocks
{
    public class MockPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return "MockPassword";
        }

        public bool VerifyPassword(string password, string storedHash)
        {
            return true;
        }
    }
}
