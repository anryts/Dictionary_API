using MongoDB.Bson.Serialization.Attributes;

namespace tg_api.Models
{
        /// <summary>
        /// uses in DB
        /// </summary>
        public class Word
        {
            /// <summary>
            /// field word is id 
            /// </summary>
            [BsonId]
            public string word { get; set; }

            public Word(string word)
        {
            this.word = word;
        }
      
        }
    }


