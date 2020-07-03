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
        public Task<User> GetUserById(Guid id);
        public Task<bool> UpdateUser(Guid id, User user);
        public Task<bool> CreateUser(User user);
        public Task<bool> DeleteUser(Guid id);
        public bool UserExists(Guid id);
    }
 }

