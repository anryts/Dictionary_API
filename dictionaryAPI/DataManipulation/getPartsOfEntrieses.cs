using System;
using System.Collections.Generic;
using dictionaryAPI.Models;


namespace dictionaryAPI.DataManipulation
{
    internal static class GetPartsOfEntries 
    {
        private static readonly Random Rn = new Random();
        public static string ReturnRandomExample(RootOfSentences word)
        {
            List<string> examples = new();
            foreach (var results in word.Results)
            {
                foreach (var lexicalEntry in results.LexicalEntries)
                {
                    foreach (var sentence in lexicalEntry.Sentences)
                    {
                        examples.Add(sentence.Text);
                    }
                }
            }
            return examples[Rn.Next(0, examples.Count)];
        }

        ///<summary>
        ///This method return a list 
        ///element at index 0 is PhoneticSpelling: example "ˈflaʊə"
        ///element at index 1 is ShortDefinition
        ///</summary>
        public static List<string> ReturnDefinitionWithPronunciation(RootOfEntries word)
        {
            var returnList = new List<string>();
            var listDefinitions = new List<string>();
            string textPronunce = default;
            foreach (var result in word.Results)
            {
                foreach (var lexicalEntry in result.LexicalEntries)
                {
                    foreach (var entry in lexicalEntry.Entries)
                    { 
                        foreach (var tmp in entry.Pronunciations)
                        {
                            if (tmp.PhoneticSpelling != null)
                            {
                                textPronunce = tmp.PhoneticSpelling;
                                break;
                            }
                        }
                        foreach (var sense in entry.Senses)
                        {
                            foreach (var tmp in sense.ShortDefinitions)
                            {
                                listDefinitions.Add(tmp);
                            }
                        }
                            
                    }
                }
            }
            returnList.Add(textPronunce);
            returnList.Add(listDefinitions[Rn.Next(0, listDefinitions.Count - 1)]);
            return returnList;
        }

        public static string ReturnVoicePronunce (RootOfEntries word)
        {
            foreach (var result in word.Results)
            {
                foreach (var lexicalEntry in result.LexicalEntries)
                {
                    foreach (var entry in lexicalEntry.Entries)
                    {
                        foreach (var tmp in entry.Pronunciations)
                        {
                            if (tmp.PhoneticSpelling != null)
                            {
                                return tmp.AudioFile;
                            }
                        }
                        
                    }
                }
            }
            return null;
        }

        public static string RandomSynonym (RootOfEntries word)
        {
            var listOfSynonyms = new List<string>();
            try
            {
                foreach (var result in word.Results)
                {
                    foreach (var lexicalEntry in result.LexicalEntries)
                    {
                        foreach (var entry in lexicalEntry.Entries)
                        {
                            foreach (var sense in entry.Senses)
                            {
                                foreach (var tmp in sense.Synonyms)
                                {
                                    listOfSynonyms.Add(tmp.Text);
                                }
                            }
                        }
                    }
                }
                return listOfSynonyms[Rn.Next(0, listOfSynonyms.Count - 1)];
            }
            catch
            {
                return null;
            }
        }
    }

}
