using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace tg_api.Modes
{
    public class WordResponse
    {
        public  IEnumerable<string> word { get; set; }
        public IEnumerable<Meaning> meanings { get; set; }
        public IEnumerable<Phonetic> phonetics { get; set; }
    }

    public class WordResponesForTG
    {
       public List<string[]> meanings { get; set; }
        public List<string> synonyms { get; set; }
        public string audio { get; set; }
        public string word { get; set; }
        public string text_phonetic { get; set; }
    }

}


