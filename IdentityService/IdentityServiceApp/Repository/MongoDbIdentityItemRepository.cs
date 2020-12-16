using System;
using System.Collections.Generic;
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

        public void CreateItem(IdentityItem item)
        {
            _identityItemsCollection.InsertOne(item);
        }

        public void UpdateItem(IdentityItem updatedItem)
        {
            var filter = _filterDefinitionBuilder.Eq(existingItem => existingItem.Id, updatedItem.Id);
            _identityItemsCollection.ReplaceOne(filter, updatedItem);
        }

        public IdentityItem GetItem(Guid id)
        {
            var filter = _filterDefinitionBuilder.Eq(item => item.Id, id);
            return _identityItemsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<IdentityItem> GetItems()
        {
            return _identityItemsCollection.Find(new BsonDocument()).ToList();
        }

        public void DeleteItem(Guid id)
        {
            var filter = _filterDefinitionBuilder.Eq(item => item.Id, id);
            _identityItemsCollection.DeleteOne(filter);
        }
    }
}
