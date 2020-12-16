using System;
using System.Collections.Generic;
using System.Linq;
using IdentityServiceApp.Models;

namespace IdentityServiceApp.Repository
{
    public class InMemIdentityItemRepository : IIdentityRepository
    {
        private readonly List<IdentityItem> _items;
        public InMemIdentityItemRepository()
        {
            _items = new List<IdentityItem>()
            {
                new() {Id = Guid.NewGuid(), Name = "Risul"},
                new() {Id = Guid.NewGuid(), Name = "Karim"},
                new() {Id = Guid.NewGuid(), Name = "Ankon"},
                new() {Id = Guid.NewGuid(), Name = "Arafat"}
            };
        }

        public IEnumerable<IdentityItem> GetItems()
        {
            return _items;
        }

        public void CreateItem(IdentityItem item)
        {
            _items.Add(item);
        }

        public void UpdateItem(IdentityItem updatedItem)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == updatedItem.Id);
            _items[index] = updatedItem;
        }

        public void DeleteItem(Guid id)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == id);
            _items.RemoveAt(index);
        }

        public IdentityItem GetItem(Guid id)
        {
            return _items.SingleOrDefault(item => item.Id == id);
        }
    }
}
