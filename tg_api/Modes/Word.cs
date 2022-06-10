﻿using System.Collections.Generic;

namespace tg_api.Modes
{


    public class Definition
    {
        public string definition { get; set; }
        public List<object> synonyms { get; set; }
        public List<object> antonyms { get; set; }
    }

    //public class License
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}

    public class Meaning
    {
        //public string partOfSpeech { get; set; }
        public List<Definition> definitions { get; set; }
        public List<object> synonyms { get; set; }
        public List<object> antonyms { get; set; }
    }

    public class Phonetic
    {
        public string text { get; set; }
        public string audio { get; set; }
        //public string sourceUrl { get; set; }
       // public License license { get; set; }
    }

    public class Word
    {
        public string word { get; set; }
       // public string phonetic { get; set; }
        public List<Phonetic> phonetics { get; set; }
        public List<Meaning> meanings { get; set; }
      //  public License license { get; set; }
       // public List<string> sourceUrls { get; set; }
    }



}



