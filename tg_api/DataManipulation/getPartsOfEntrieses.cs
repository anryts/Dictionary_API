using System;
using System.Collections.Generic;
using tg_api.Models;


namespace tg_api.DataManipulation
{
    static class getPartsOfEntries 
    {
        static Random _rn = new Random();
        //public static string ReturnRandomExample (RootOfSentences word)
        //{
        //    List<string> _examples = new();
        //    foreach (var results in word.results)
        //    {
        //        foreach (var lexicalEntry in results.lexicalEntries)
        //        {
        //            foreach (var sentence in lexicalEntry.sentences)
        //            {
        //                _examples.Add(sentence.text);
        //            }
        //        }
        //    }
        //    return _examples[_rn.Next(0,_examples.Count)];
        //}

        ///<summary>
        ///This methods return a list 
        ///element at index 0 is PhoneticSpelling: example "ˈflaʊə"
        ///element at index 1 is ShortDefinition
        ///</summary>
        public static List<string> ReturnDefinitionWithPronunciation (RootOfEntries word)
        {
            var _return_list = new List<string>();
            var _list_definitions = new List<string>();
            foreach (var result in word.results)
            {
                foreach (var lexicalEntry in result.lexicalEntries)
                {
                    foreach (var entry in lexicalEntry.entries)
                    { 
                        foreach (var tmp in entry.pronunciations)
                        {
                            if (tmp.phoneticSpelling != null)
                            {
                                _return_list.Add(tmp.phoneticSpelling);
                                break;
                            }
                        }
                        foreach (var sense in entry.senses)
                            _list_definitions.Add(sense.shortDefinitions[_rn.Next(0, sense.shortDefinitions.Count - 1)]);
                    }
                }
            }
            _return_list.Add(_list_definitions[_rn.Next(0, _list_definitions.Count - 1)]);
            return _return_list;
        }

        public static string ReturnVoicePronunce (RootOfEntries word)
        {
            foreach (var result in word.results)
            {
                foreach (var lexicalEntry in result.lexicalEntries)
                {
                    foreach (var entry in lexicalEntry.entries)
                    {
                        foreach (var tmp in entry.pronunciations)
                        {
                            if (tmp.phoneticSpelling != null)
                            {
                                return tmp.audioFile;
                            }
                        }
                        
                    }
                }
            }
            return null;
        }

        public static string RandomSynonym (RootOfEntries word)
        {
            var _list_of_synonyms = new List<string>();
            foreach (var result in word.results)
            {
                foreach (var lexicalEntry in result.lexicalEntries)
                {
                    foreach (var entry in lexicalEntry.entries)
                    {
                        foreach (var sense in entry.senses)
                        {
                            foreach (var tmp in sense.synonyms)
                            {
                                _list_of_synonyms.Add(tmp.text);
                            }
                        }
                    }
                }
            }
            return _list_of_synonyms[_rn.Next(0, _list_of_synonyms.Count - 1)];
        }
    }

}
