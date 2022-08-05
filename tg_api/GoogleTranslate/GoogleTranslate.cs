using Google.Cloud.Translation.V2;
using tg_api.Support;

namespace tg_api.GoogleTranslate
{
    static class GoogleTranslate
    {
        static TranslationClient _client  = TranslationClient.CreateFromApiKey(API_KEYS._google_translate_api);
        public  static string DetectLanguage (string word)
        {
            return _client.DetectLanguage(word).Language;
        }


        /// <summary>
        ///target_lang - in which language this text will be translate 
        ///example : 'en'
        /// </summary>
        public  static string TranslateWord (string word, string target_lang) 
        {
            return _client.TranslateText(word, target_lang).TranslatedText;
        }
        /// <summary>
        /// this method doesn't support ukranian :(
        /// </summary>
        /// <param name="sentence"> your sentence</param>
        /// <param name="origin_lang">you can put nothing</param>
        /// <returns></returns>
        public static string TranslateSentence(string sentence, string origin_lang, string target_lang)
        {
            return _client.TranslateText(sentence, target_lang, origin_lang==null?DetectLanguage(sentence):origin_lang).TranslatedText;
        }
    }
}
