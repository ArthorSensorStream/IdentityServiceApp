using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServiceApp.Models;

namespace IdentityServiceApp.Repository
{
    public class InMemIdentityItemRepository : IIdentityRepository
    {
        private readonly IdentityItem[] _items;
        public InMemIdentityItemRepository()
        {
            _items = new[]
            {
                new IdentityItem {Id = Guid.NewGuid(), Name = "Risul"},
                new IdentityItem {Id = Guid.NewGuid(), Name = "Karim"},
                new IdentityItem {Id = Guid.NewGuid(), Name = "Ankon"},
                new IdentityItem {Id = Guid.NewGuid(), Name = "Arafat"}
            };
        }

        public IEnumerable<IdentityItem> GetItems()
        {
            return _items;
        }

        public IdentityItem GetItem(Guid id)
        {
            return _items.SingleOrDefault(item => item.Id == id);
        }
    }
}
