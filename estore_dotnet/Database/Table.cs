using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace estore_dotnet.Databases
{
    /// <summary>
    /// General data for tables in the system (information about creating, updating and deleting data).
    /// <para>Author: gnohP18</para>
    /// <para>Created: 08/08/2023</para>
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Data creation time
        /// </summary>
        [BsonElement("created_at")]
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { set; get; }
        /// <summary>
        /// Data creator id
        /// </summary>
        [BsonElement("created_by")]
        [JsonPropertyName("created_by")]
        public long CreatedBy { set; get; }
        /// <summary>
        /// Data creator IP
        /// </summary>
        [BsonElement("created_ip")]
        [JsonPropertyName("created_ip")]
        public string CreatedIp { set; get; }
        /// <summary>
        /// Data updated time
        /// </summary>
        [BsonElement("updated_at")]
        [JsonPropertyName("updated_at")]
        public DateTimeOffset? UpdatedAt { set; get; }
        /// <summary>
        /// Data updater id
        /// </summary>
        [BsonElement("updated_by")]
        [JsonPropertyName("updated_by")]
        public long? UpdatedBy { set; get; }
        /// <summary>
        /// Data updater IP
        /// </summary>
        [BsonElement("updated_ip")]
        [JsonPropertyName("updated_ip")]
        public string UpdatedIp { set; get; }
        /// <summary>
        /// Data deleted time
        /// </summary>
        [BsonElement("deleted_at")]
        [JsonPropertyName("deleted_at")]
        public DateTimeOffset? DeletedAt { set; get; }
        /// <summary>
        /// Data deleter id
        /// </summary>
        [BsonElement("deleted_by")]
        [JsonPropertyName("deleted_by")]
        public long? DeletedBy { set; get; }
        /// <summary>
        /// Data deleter IP
        /// </summary>
        [BsonElement("deleted_ip")]
        [JsonPropertyName("deleted_ip")]
        public string DeletedIp { set; get; }
        /// <summary>
        /// Flag check deleted data
        /// </summary>
        [BsonElement("del_flag")]
        [JsonPropertyName("del_flag")]
        public bool DelFlag { set; get; }
        /// <summary>
        /// Physically erase data
        /// </summary>
        [BsonElement("force_del")]
        [JsonPropertyName("force_del")]
        public bool ForceDel { set; get; } = false;
    }
}
