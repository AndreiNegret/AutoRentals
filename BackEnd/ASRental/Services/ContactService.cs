using ASRental.Models;
using ASRental.Repository.Interfaces;
using ASRental.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASRental.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository ContactRepository)
        {
            _contactRepository = ContactRepository;
        }

        public async Task<bool> CreateContact(Contact contact)
        {
            try
            {
                _contactRepository.Create(contact);
                await _contactRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteContact(Guid id)
        {
            try
            {
                var contact = await GetContactById(id);
                _contactRepository.Delete(contact);
                await _contactRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<List<Contact>> GetAllContacts()
        {
            try
            {
                return _contactRepository.FindAll().OrderByDescending(contact => contact.Email).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Task<Contact> GetContactById(Guid id)
        {
            try
            {
                return _contactRepository.FindByCondition(contact => contact.ContactId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> UpdateContact(Guid id, Contact contact)
        {
            try
            {
                await GetContactById(id);
                _contactRepository.Update(contact);
                await _contactRepository.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public bool ContactExists(Guid id)
        {
            return _contactRepository.FindByCondition(e => e.ContactId == id).Any();
        }
    }
}