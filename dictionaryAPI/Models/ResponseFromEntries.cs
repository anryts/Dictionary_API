using System.Collections.Generic;

namespace dictionaryAPI.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
   
    /// <summary>
    /// this response become from https://od-api.oxforddictionaries.com/api/v2/entries
    /// </summary>
    public class RootOfEntries
    {
        public string Id { get; set; }
        public Metadata Metadata { get; set; }
        public List<Result> Results { get; set; }
        public string Word { get; set; }
    }
    public class Construction
    {
        public string Text { get; set; }
    }

    public class Derivative
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public class DomainClass
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public class Entry
    {
        public List<string> Etymologies { get; set; }
        public List<Pronunciation> Pronunciations { get; set; }
        public List<Sense> Senses { get; set; }
        public List<GrammaticalFeature> GrammaticalFeatures { get; set; }
    }

    public class Example
    {
        public string Text { get; set; }
    }

    public class GrammaticalFeature
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public class LexicalCategory
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public class LexicalEntry
    {
        public List<Derivative> Derivatives { get; set; }
        public List<Entry> Entries { get; set; }
        public string Language { get; set; }
        public LexicalCategory LexicalCategory { get; set; }
        public string Text { get; set; }
    }

    public class Metadata
    {
        public string Operation { get; set; }
        public string Provider { get; set; }
        public string Schema { get; set; }
    }

    public class Note
    {
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public class Pronunciation
    {
        public string AudioFile { get; set; }
        public List<string> Dialects { get; set; }
        public string PhoneticNotation { get; set; }
        public string PhoneticSpelling { get; set; }
    }

    public class Region
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public class Register
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public class Result
    {
        public string Id { get; set; }
        public string Language { get; set; }
        public List<LexicalEntry> LexicalEntries { get; set; }
        public string Type { get; set; }
        public string Word { get; set; }
    }


    public class SemanticClass
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }

    public class Sense
    {
        public List<string> Definitions { get; set; }
        public List<DomainClass> DomainClasses { get; set; }
        public string Id { get; set; }
        public List<SemanticClass> SemanticClasses { get; set; }

        public List<string> ShortDefinitions { get; set; }

        public List<Subsense> Subsenses { get; set; }
        public List<Synonym> Synonyms { get; set; }
        public List<ThesaurusLink> ThesaurusLinks { get; set; }
        public List<Example> Examples { get; set; }
        public List<Note> Notes { get; set; }
        public List<Region> Regions { get; set; }
        public List<Register> Registers { get; set; }
    }

    public class Subsense
    {
        public List<string> Definitions { get; set; }
        public List<DomainClass> DomainClasses { get; set; }
        public List<Example> Examples { get; set; }
        public string Id { get; set; }
        public List<SemanticClass> SemanticClasses { get; set; }
        public List<string> ShortDefinitions { get; set; }
        public List<Construction> Constructions { get; set; }
        public List<Note> Notes { get; set; }
    }

    public class Synonym
    {
        public string Language { get; set; }
        public string Text { get; set; }
    }

    public class ThesaurusLink
    {
        public string EntryId { get; set; }
        public string SenseId { get; set; }
    }



}
