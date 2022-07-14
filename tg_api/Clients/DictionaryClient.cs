using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using tg_api.Models;
using tg_api.Support;

namespace tg_api.Clients
{
    public class DictionaryClient : IDictionaryClient
    {
       private readonly HttpClient _httpClient;

        public DictionaryClient()
        {          
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(Links._dict_address);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Add("app_id", API_KEYS._app_id);
            _httpClient.DefaultRequestHeaders.Add("app_key", API_KEYS._app_key);

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
