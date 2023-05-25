using AlfaSoft.Models;

namespace AlfaSoft.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(Guid id);
        Task CreateAsync(Contact contact);
        Task UpdateAsync(Contact contact);
        Task Delete(Guid id);
    }
}
