using System;
using System.Collections.Generic;
using IdentityServiceApp.Models;

namespace IdentityServiceApp.Repository
{
    public interface IIdentityRepository
    {
        IdentityItem GetItem(Guid id);
        IEnumerable<IdentityItem> GetItems();
    }
}