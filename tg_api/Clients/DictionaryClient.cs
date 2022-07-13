using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Google.Cloud.Translation.V2;
using System.Threading.Tasks;
using tg_api.Clients;
using tg_api.Models;


namespace tg_api.Cleints
{
    public class DictionaryClient : IDictionaryClient
    {

      
        private static string _adress;
        HttpClient _client;
        HttpClient _httpClient;
       public List<Word> words = new();

        public DictionaryClient()
        {
            _adress = Constants._adress;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_adress);
            _httpClient = new HttpClient();
            _adress = Constants._dict_address_entries;
            _httpClient.BaseAddress = new Uri(_adress);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("app_id", "6c41fe93");
            _httpClient.DefaultRequestHeaders.Add("app_key", "5cf10e177dc05e3957298e8121ee7922");

        }

        public async Task<RootOfEntries> GetWordFromAPI(string word)
        {
            var response = await _httpClient.GetAsync(word);
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var tmp = JsonConvert.DeserializeObject<RootOfEntries>(content);
            //var result = tmp[0];
            return tmp;
        }


        //public async Task<RootOfSentences> GetExampleByWord (string word)
        //{
        //    var response = await _httpClient.GetAsync(word);
        //    response.EnsureSuccessStatusCode();
        //    var content = response.Content.ReadAsStringAsync().Result;
        //    var tmp = JsonConvert.DeserializeObject<RootOfSentences>(content);
        //    return  tmp;
        //}

        public async Task<List<Word>> AllWords ()
        {
            return words;
        }

        public void TakeToWordCollection(Word item)
        {
            words.Add(item);
            return;
        }


        public void DeleteWordFromCollection(Word word)
        {
            var result = words.Find(x => x.word ==word.word);
            if (result == null)
                return;
            words.Remove(result);
        }

        public void TakeToWordCollection(Word word, string NameCollection)
        {
            throw new NotImplementedException();
        }

        public Task<List<Word>> AllWords(string collectionName)
        {
            throw new NotImplementedException();
        }

        Task<Word> IDictionaryClient.GetWordFromAPI(string word_t)
        {
            throw new NotImplementedException();
        }
    }
}
