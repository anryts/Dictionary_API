using System.Collections.Generic;
using System.Linq;
using tg_api.Modes;

namespace tg_api.DataManipulation
{
    public class TransferFromWordToResponse
    {
        public WordResponesForTG GetResponseFromWord(Word tmp)
        {
            List<string> _synonyms = new();
            List<string[]> words = new();

            foreach (var part in tmp.meanings)
            {
                var part_of_speech = part.partOfSpeech;
                if (part.definitions != null)
                {
                    foreach (var definition in part.definitions)
                    {
                        words.Add(new string[2] { part_of_speech, definition.definition });
                    }
                    foreach (var nt in part.synonyms)
                    {
                        if (nt != null)
                            _synonyms.Add(nt.ToString());
                    }
                }

            }
            var result = new WordResponesForTG
            {
                word = tmp.word,
                audio = tmp.phonetics.Select(x => x.audio).FirstOrDefault(),
                meanings = words,
                synonyms = _synonyms,
                text_phonetic = tmp.phonetics[1].text
            };
            return result;
        }

    }
}
