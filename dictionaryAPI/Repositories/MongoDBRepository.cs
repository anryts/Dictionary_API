using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using dictionaryAPI.Models;
using dictionaryAPI.Clients;

namespace dictionaryAPI.Repositories
{
    public class MongoDBRepository : IDBRepository
    {
        private const string databaseName = "collection";
        public IMongoCollection<Word> itemsCollection;
        private readonly FilterDefinitionBuilder<Word> filterBuilder = Builders<Word>.Filter;
        IMongoDatabase database;
        public MongoDBRepository(IMongoClient mongoClient)
        {
            database = mongoClient.GetDatabase(databaseName);
        }


        public async Task<List<string>> GetAllWords(string collectionName)
        {
            List<string> words = new List<string>();
            itemsCollection = database.GetCollection<Word>(collectionName);
            var documents = itemsCollection.Find(new BsonDocument()).ToList();
            documents.ForEach(x => words.Add(x.word));
            return words;
        }

        public void PutWordToCollection(string item, string collectionName)
        {
            Word db_word = new( item);
            itemsCollection = database.GetCollection<Word>(collectionName);
            itemsCollection.InsertOne(db_word);
        }

        public void DeleteWordFromCollection(string word, string collectionName)
        {
            //var filter = filterBuilder.Eq(item => item.word, word.word);
            //itemsCollection.DeleteOne(filter);
        }

        public void PutCollectionToCollection(List<string> collection, string collectionName)
        {
            itemsCollection = database.GetCollection<Word>(collectionName);
            collection.ForEach(x => itemsCollection.InsertOne(new Word(x)));
        }
    }
}
