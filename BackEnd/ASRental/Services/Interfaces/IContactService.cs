using ASRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services.Interfaces
{
    public interface IContactService
    {
        public Task<List<Contact>> GetAllContacts();
        public Task<Contact> GetContactById(Guid id);
        public Task<bool> UpdateContact(Guid id, Contact contact);
        public Task<bool> CreateContact(Contact contact);
        public Task<bool> DeleteContact(Guid id);
        public bool ContactExists(Guid id);
    }
}
