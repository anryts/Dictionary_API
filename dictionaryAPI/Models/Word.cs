using MongoDB.Bson.Serialization.Attributes;

namespace dictionaryAPI.Models
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
            public string Text { get; set; }

            public Word(string text)
        {
            this.Text = text;
        }
      
        }
    }


