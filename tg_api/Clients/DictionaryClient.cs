using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using tg_api.Clients;
using tg_api.Models;


namespace tg_api.Cleints
{
    public class DictionaryClient : IDictionaryClient
    {
       private readonly HttpClient _httpClient;

        public DictionaryClient()
        {          
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Constants._dict_address);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("app_id", "6c41fe93");
            _httpClient.DefaultRequestHeaders.Add("app_key", "5cf10e177dc05e3957298e8121ee7922");

        }

        public async Task<RootOfEntries> GetWordFromAPI(string word)
        {
            var response = await _httpClient.GetAsync("entries/" +$"{GoogleTranslate.GoogleTranslate.DetectLanguage(word)}/"+word);
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var tmp = JsonConvert.DeserializeObject<RootOfEntries>(content);
           
            return tmp;
        }


        public async Task<RootOfSentences> GetExampleByWord(string word)
        {
            var response = await _httpClient.GetAsync("sentences/"+$"{GoogleTranslate.GoogleTranslate.DetectLanguage(word)}/"+word);
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var tmp = JsonConvert.DeserializeObject<RootOfSentences>(content);
            return tmp;
        }
    }
}
