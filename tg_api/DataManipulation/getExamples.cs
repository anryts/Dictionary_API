using System;
using System.Collections.Generic;
using tg_api.Modes;


namespace tg_api.DataManipulation
{
    public class getExamples
    {
        public string ReturnRandomExample (WordDictionary word)
        {
            Random rn = new Random();
            List<string> examples = new();
            foreach (var tmp in word.results)
            {
                foreach (var tm1 in tmp.lexicalEntries)
                {
                    foreach (var tm2 in tm1.sentences)
                    {
                        examples.Add(tm2.text);
                    }
                }
            }

            return examples[rn.Next(0,examples.Count)];
        }
    }
}
