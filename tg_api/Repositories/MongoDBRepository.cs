using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using tg_api.Clients;
using tg_api.Models;

namespace tg_api.Repositories
{
    public class MongoDBRepository : IDBRepository
    {
        private const string databaseName = "collection";
        public IMongoCollection<Word> itemsCollection;
        private Word _db_word = new Word();
        private readonly FilterDefinitionBuilder<Word> filterBuilder = Builders<Word>.Filter;
        IMongoDatabase database;
        public MongoDBRepository(IMongoClient mongoClient)
        {
            database = mongoClient.GetDatabase(databaseName);
        }

        //public void CreateItem(string word, string collectionName)
        //{
        //    itemsCollection = database.GetCollection<Word>(collectionName);
        //    itemsCollection.InsertOne(Word);
        //}

        public async Task<List<string>> AllWords(string collectionName)
        {
            List<string> words = new List<string>();
            itemsCollection = database.GetCollection<Word>(collectionName);
            var documents = itemsCollection.Find(new BsonDocument()).ToList();
            documents.ForEach(x => words.Add(x.word));
            return words;
        }

        public void TakeWordToCollection(string item, string collectionName)
        {
            _db_word.word = item;
            itemsCollection = database.GetCollection<Word>(collectionName);
            itemsCollection.InsertOne(_db_word);
        }

        public void DeleteWordFromCollection(string word, string collectionName)
        {
            //var filter = filterBuilder.Eq(item => item.word, word.word);
            //itemsCollection.DeleteOne(filter);
        }

       
    }
}
