using System.Collections.Generic;

namespace dictionaryAPI.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<RootOfSentences>(myJsonResponse);    

    /// <summary>
    /// this response become from https://od-api.oxforddictionaries.com/api/v2/sentences
    /// </summary>
    public abstract class RootOfSentences
    {
        public string Id { get; set; }
        public List<Result> Results { get; set; }
        public string Word { get; set; }

        public abstract class LexicalCategory
        {
            public string Text { get; set; }
        }

        public class LexicalEntry
        {
            public string Language { get; set; }
            public LexicalCategory LexicalCategory { get; set; }
            public List<Sentence> Sentences { get; set; }
            public string Text { get; set; }
        }



        public class Region
        {
            public string Text { get; set; }
        }

        public class Result
        {
            public string Language { get; set; }

            public List<LexicalEntry> LexicalEntries { get; set; }

            public string Type { get; set; }
            public string Text { get; set; }
        }

        public class Sentence
        {
            public List<Region> Regions { get; set; }
            public List<string> SenseIds { get; set; }
            public string Text { get; set; }
        }
    }


}
