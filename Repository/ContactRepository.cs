using AlfaSoft.Context;
using AlfaSoft.Models;
using Microsoft.EntityFrameworkCore;

namespace AlfaSoft.Repository
{
    public class ContactRepository : IContactRepository
    {
        private AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Contact contact)
        {
            if (contact.IsValid())
            {
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.ID == id);
            if (contact is not null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }

        public async Task<IEnumerable<Contact>> GetAllAsync() => await _context.Contacts.ToListAsync();

        public async Task<Contact> GetByIdAsync(Guid id)
        {
            var result = await _context.Contacts.Where(x => x.ID == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateAsync(Contact contact)
        {
            if (contact.IsValid())
            {
                _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}
