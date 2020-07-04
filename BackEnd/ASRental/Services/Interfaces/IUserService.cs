using ASRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services.Interfaces
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
        public Task<User> GetUserById(string id);
        public Task<bool> UpdateUser(string id, User user);
        public Task<bool> CreateUser(User user);
        public Task<bool> DeleteUser(string id);
        public bool UserExists(string id);
    }
 }

