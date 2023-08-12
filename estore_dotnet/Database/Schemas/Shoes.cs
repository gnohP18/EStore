using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using estore_dotnet.Databases;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace estore_dotnet.Databases
{
    [BsonIgnoreExtraElements]
    public class Shoes 
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = null!;

        [BsonElement("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [BsonElement("color")]
        [JsonPropertyName("color")]
        public string Color { get; set; } = null!;

        [BsonElement("size")]
        [JsonPropertyName("size")]
        public int Size { get; set; } 

        [BsonElement("quantity")]
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [BsonElement("slug")]
        [JsonPropertyName("slug")]
        public string Slug { get; set; } = null!;

        [BsonElement("thumbNail")]
        [JsonPropertyName("thumbNail")]
        public string Thumbnail { get; set; } = null!;
    }
}