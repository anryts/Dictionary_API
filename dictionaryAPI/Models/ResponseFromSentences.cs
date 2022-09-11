using System.Collections.Generic;

namespace dictionaryAPI.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<RootOfSentences>(myJsonResponse);    

    /// <summary>
    /// this response become from https://od-api.oxforddictionaries.com/api/v2/sentences
    /// </summary>
    public class RootOfSentences
    {
        public string id { get; set; }
        public List<Result> results { get; set; }
        public string word { get; set; }

        public class LexicalCategory
        {
            public string id { get; set; }
            public string text { get; set; }
        }

        public class LexicalEntry
        {
            public string language { get; set; }
            public LexicalCategory lexicalCategory { get; set; }
            public List<Sentence> sentences { get; set; }
            public string text { get; set; }
        }



        public class Region
        {
            public string id { get; set; }
            public string text { get; set; }
        }

        public class Result
        {
            public string id { get; set; }
            public string language { get; set; }
            public List<LexicalEntry> lexicalEntries { get; set; }
            public string type { get; set; }
            public string word { get; set; }
        }

        public class Sentence
        {
            public List<Region> regions { get; set; }
            public List<string> senseIds { get; set; }
            public string text { get; set; }
        }
    }


}
