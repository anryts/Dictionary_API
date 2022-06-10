using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using tg_api.Modes;

namespace tg_api.Cleints
{
    public class DictionaryClient
    {

        private static string _adress;
        private static string _app_key;
        private static string _app_id;
        HttpClient _client;
        static List<List<Word>> words = new();

        public DictionaryClient()
        {
            _adress = Constants._adress;
            _app_key = Constants._app_key;
            _app_id = Constants._app_id;
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_adress);
           
           
        }

        public async Task<List<Word>> GetWordByWord(string word_t)
        {
            var response = await _client.GetAsync(word_t);
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<List<Word>>(content);
            
            return result;
        }

        public async Task<List<List<Word>>> AllWords ()
        {
            return words;
        }

        public void TakeToWordCollection(List<Word> item)
        {
            words.Add(item);
            return;
        }

        public void DeleteWordFromCollection (string word)
        {

           var index =  words.FindIndex(x =>x.Find(x => x.word == word).word == word);
           
            // int index = items.FindIndex(existingItem => existingItem.ID == id);
            words.RemoveAt(index);
            
        }
   
    }
}
