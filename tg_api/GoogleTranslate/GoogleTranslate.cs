using Google.Cloud.Translation.V2;
namespace tg_api.GoogleTranslate
{
    static class GoogleTranslate
    {
        static TranslationClient _client  = TranslationClient.CreateFromApiKey("AIzaSyCf3vMKkpT1Z9ifF3z-1-JvizzCO-uatPY");
        static string DetectLanguage (string word)
        {
            return _client.DetectLanguage(word).Language;
        }


        /// <summary>
        ///target_lang - in which language this text will be translate 
        ///example : 'en'
        /// </summary>
        static string TranslateWord (string word, string target_lang) 
        {
            return _client.TranslateText(word, target_lang).TranslatedText;
        }
    }
}
