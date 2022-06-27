using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using tg_api.Clients;
using tg_api.Modes;

namespace tg_api.Repositories
{
    public class MongoDBRepository : IDictionaryClient
    {
        private const string databaseName = "collection";
       // readonly  string collectionName = "words";
        public  IMongoCollection<Word> itemsCollection;
        private readonly FilterDefinitionBuilder<Word> filterBuilder = Builders<Word>.Filter;
        IMongoDatabase database;
        public MongoDBRepository(IMongoClient mongoClient)
        {
            database = mongoClient.GetDatabase(databaseName);
            //itemsCollection = database.GetCollection<Word>(collectionName);
        }

        public void CreateItem (Word word, string collectionName)
        {
            itemsCollection = database.GetCollection<Word>(collectionName);
            itemsCollection.InsertOne(word);
        }

        public  async Task<List<Word>> AllWords(string collectionName)
        {
            //List<Word> words = new List<Word>();
            itemsCollection = database.GetCollection<Word>(collectionName);
            var documents =  itemsCollection.Find(new BsonDocument()).ToList();
            return documents;
        }

       
        //public Task<Word> GetWordByWord(string word_t)
        //{
        //    throw new System.NotImplementedException();
        //}

        public void TakeToWordCollection(Word item,  string collectionName)
        {
            itemsCollection = database.GetCollection<Word>(collectionName);
            itemsCollection.InsertOne(item);
        }

        public void DeleteWordFromCollection(Word word)
        {
            var filter = filterBuilder.Eq(item => item.word, word.word);
            itemsCollection.DeleteOne(filter);
        }

        public Task<Word> GetWordByWord(string word_t)
        {
            throw new System.NotImplementedException();
        }

       
    }
}
