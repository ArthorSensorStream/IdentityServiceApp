using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServiceApp.Models;

namespace IdentityServiceApp.Repository
{
    public interface IIdentityRepository
    {
        Task<IdentityItem> GetItemAsync(Guid id);
        Task<IEnumerable<IdentityItem>> GetItemsAsync();

        Task CreateItemAsync(IdentityItem item);

        Task UpdateItemAsync(IdentityItem updatedItem);

        Task DeleteItemAsync(Guid id);
    }
}