using System;
using System.Collections.Generic;
using dictionaryAPI.Models;


namespace dictionaryAPI.DataManipulation
{
    static class getPartsOfEntries 
    {
        static Random _rn = new Random();
        public static string ReturnRandomExample(RootOfSentences word)
        {
            List<string> _examples = new();
            foreach (var results in word.results)
            {
                foreach (var lexicalEntry in results.lexicalEntries)
                {
                    foreach (var sentence in lexicalEntry.sentences)
                    {
                        _examples.Add(sentence.text);
                    }
                }
            }
            return _examples[_rn.Next(0, _examples.Count)];
        }

        ///<summary>
        ///This method return a list 
        ///element at index 0 is PhoneticSpelling: example "ˈflaʊə"
        ///element at index 1 is ShortDefinition
        ///</summary>
        public static List<string> ReturnDefinitionWithPronunciation(RootOfEntries word)
        {
            var return_list = new List<string>();
            var list_definitions = new List<string>();
            string text_pronunce = default;
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
                                text_pronunce = tmp.phoneticSpelling;
                                break;
                            }
                        }
                        foreach (var sense in entry.senses)
                        {
                            foreach (var tmp in sense.shortDefinitions)
                            {
                                list_definitions.Add(tmp);
                            }
                        }
                            
                    }
                }
            }
            return_list.Add(text_pronunce);
            return_list.Add(list_definitions[_rn.Next(0, list_definitions.Count - 1)]);
            return return_list;
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
            try
            {
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
            catch
            {
                return null;
            }
        }
    }

}
