using System.Collections.Generic;

namespace tg_api.Modes
{


    public class Word
    {
        public string id { get; set; }
        public Metadata metadata { get; set; }
        public List<Result> results { get; set; }
        public string word { get; set; }
    }




    public class Entry
        {
            public List<Pronunciation> pronunciations { get; set; }
        }

        public class LexicalCategory
        {
            public string id { get; set; }
            public string text { get; set; }
        }

        public class LexicalEntry
        {
            public List<Entry> entries { get; set; }
            public string language { get; set; }
            public LexicalCategory lexicalCategory { get; set; }
            public string text { get; set; }
        }

        public class Metadata
        {
            public string operation { get; set; }
            public string provider { get; set; }
            public string schema { get; set; }
        }

        public class Pronunciation
        {
            public string audioFile { get; set; }
            public List<string> dialects { get; set; }
            public string phoneticNotation { get; set; }
            public string phoneticSpelling { get; set; }
        }

        public class Result
        {
            public string id { get; set; }
            public string language { get; set; }
            public List<LexicalEntry> lexicalEntries { get; set; }
            public string type { get; set; }
            public string word { get; set; }
        }

       

    }



