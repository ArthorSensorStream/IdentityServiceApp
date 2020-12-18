using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServiceApp.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IdentityServiceApp.Repository
{
    public class MongoDbIdentityItemRepository: IIdentityRepository
    {
        private const string _databaseName = "IdentityDb";
        private const string _collectionName = "IdentityItems";
        private readonly IMongoCollection<IdentityItem> _identityItemsCollection;
        private readonly FilterDefinitionBuilder<IdentityItem> _filterDefinitionBuilder;
        
        public MongoDbIdentityItemRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(_databaseName);
            _identityItemsCollection = database.GetCollection<IdentityItem>(_collectionName);
            _filterDefinitionBuilder = Builders<IdentityItem>.Filter;
        }

        public async Task CreateItemAsync(IdentityItem item)
        {
            await _identityItemsCollection.InsertOneAsync(item);
        }

        public async Task UpdateItemAsync(IdentityItem updatedItem)
        {
            var filter = _filterDefinitionBuilder.Eq(existingItem => existingItem.Id, updatedItem.Id);
            await _identityItemsCollection.ReplaceOneAsync(filter, updatedItem);
        }

        public async Task<IdentityItem> GetItemAsync(Guid id)
        {
            var filter = _filterDefinitionBuilder.Eq(item => item.Id, id);
            return await _identityItemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<IdentityItem>> GetItemsAsync()
        {
            return await _identityItemsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var filter = _filterDefinitionBuilder.Eq(item => item.Id, id);
            await _identityItemsCollection.DeleteOneAsync(filter);
        }
    }
}
