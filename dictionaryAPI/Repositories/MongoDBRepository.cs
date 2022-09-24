using System;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using dictionaryAPI.Models;
using dictionaryAPI.Clients;

namespace dictionaryAPI.Repositories
{
    public class MongoDbRepository : IDBRepository
    {
        private const string DatabaseName = "collection";
        public IMongoCollection<Word> ItemsCollection;
        private readonly FilterDefinitionBuilder<Word> _filterBuilder = Builders<Word>.Filter;
        readonly IMongoDatabase _database;
        public MongoDbRepository(IMongoClient mongoClient)
        {
            _database = mongoClient.GetDatabase(DatabaseName);
        }


        public Task<List<string>> GetAllWords(string collectionName)
        {
            List<string> words = new List<string>();
            ItemsCollection = _database.GetCollection<Word>(collectionName);
            var documents = ItemsCollection.Find(new BsonDocument()).ToList();
            documents.ForEach(x => words.Add(x.Text));
            return Task.FromResult(words);
        }

        public void PutWordToCollection(string item, string collectionName)
        {
            Word dbWord = new( item);
            if (dbWord == null)  throw new ArgumentNullException(nameof(dbWord)); // in this case, probably need to add 404 status code or something else.
            ItemsCollection = _database.GetCollection<Word>(collectionName);
            ItemsCollection.InsertOne(dbWord);
        }

        public void DeleteWordFromCollection(string word, string collectionName)
        {
            //var filter = filterBuilder.Eq(item => item.word, word.word);
            //itemsCollection.DeleteOne(filter);
        }

        public void PutCollectionToCollection(List<string> collection, string collectionName)
        {
            ItemsCollection = _database.GetCollection<Word>(collectionName);
            collection.ForEach(x => ItemsCollection.InsertOne(new Word(x)));
        }
    }
}
