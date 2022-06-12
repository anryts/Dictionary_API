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
        private readonly IMongoCollection<WordResponse> itemsCollection;
        
        public MongoDBRepository(IMongoClient mongoClient)
        {

        }
        public Task<List<Word>> AllWords()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteWordFromCollection(string word)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Word>> GetWordByWord(string word_t)
        {
            throw new System.NotImplementedException();
        }

        public void TakeToWordCollection(List<Word> item)
        {
            throw new System.NotImplementedException();
        }
    }
}
