using System.Text.Json.Serialization;

namespace BookInfo.Details.Models
{
    public class BookDetails
    {
        public int Id {get; set;}

        public string Author  {get; set;}

        public int Year {get; set;}

        public string Type {get; set;}

        public int Pages {get; set;}

        public string Publisher {get; set;} 
        
        public string Language {get; set;}

        [JsonPropertyName("ISBN-10")]
        public string Isbn10 {get; set;}

        [JsonPropertyName("ISBN-13")]
        public string Isbn13 {get; set;}
    }
}