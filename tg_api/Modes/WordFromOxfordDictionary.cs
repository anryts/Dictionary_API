using System.Collections.Generic;

namespace tg_api.Modes
{
   
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

        public class Metadata
        {
            public string operation { get; set; }
            public string provider { get; set; }
            public string schema { get; set; }
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

        public class WordDictionary
        {
            public string id { get; set; }
            public Metadata metadata { get; set; }
            public List<Result> results { get; set; }
            public string word { get; set; }
        }

        public class Sentence
        {
            public List<Region> regions { get; set; }
            public List<string> senseIds { get; set; }
            public string text { get; set; }
        }

    
}
