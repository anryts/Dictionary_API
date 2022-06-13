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
        private const string collectionName = "words";
        private readonly IMongoCollection<Word> itemsCollection;
        
        public MongoDBRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            itemsCollection = database.GetCollection<Word>(collectionName);
        }

        public void CreateItem (Word word)
        {
            itemsCollection.InsertOne(word);
        }

        public Task<List<Word>> AllWords()
        {
            throw new System.NotImplementedException();
        }

       
        public Task<Word> GetWordByWord(string word_t)
        {
            throw new System.NotImplementedException();
        }

        public void TakeToWordCollection(Word item)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteWordFromCollection(Word word)
        {
            throw new System.NotImplementedException();
        }
    }
}
