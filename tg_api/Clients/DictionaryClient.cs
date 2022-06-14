using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using tg_api.Clients;
using tg_api.Modes;


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
            _adress = Constants._dict_address;
            _httpClient.BaseAddress = new Uri(_adress);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("app_id", "6c41fe93");
            _httpClient.DefaultRequestHeaders.Add("app_key", "5cf10e177dc05e3957298e8121ee7922");

        }

        public async Task<Word> GetWordByWord(string word_t)
        {
            var response = await _client.GetAsync(word_t);
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var tmp = JsonConvert.DeserializeObject<List<Word>>(content);
            var result = tmp[0];
            return result;
        }


        public async Task<WordDictionary> GetExampleByWord (string word)
        {
            var response = await _httpClient.GetAsync(word);
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var tmp = JsonConvert.DeserializeObject<WordDictionary>(content);
            return  tmp;
        }

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
    }
}
