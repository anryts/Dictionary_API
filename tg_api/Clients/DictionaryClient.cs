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
        private WebRequest webRequest;
        
        private static string _adress;
        private static string _app_key;
        private static string _app_id;
        HttpClient _client;

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
    }
}
