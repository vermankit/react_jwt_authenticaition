using System.Collections.Generic;
using api.Entities;

namespace api.Services
{
    public class UserServices : IUserService
    {
        private List<User> _users = new List<User>
        { 
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" } 
        };
        
        public User Authenticate(string username, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}