using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace ScorekeeperApi.Models
{
    public class User
    {
        /// <summary>
        /// Is required for mapping the Common Language Runtime (CLR) object to the MongoDB collection.
        /// Is annotated with [BsonId] to designate this property as the document's primary key.
        /// Is annotated with [BsonRepresentation(BsonType.ObjectId)] to allow passing the parameter as type string instead of an ObjectId structure. Mongo handles the conversion from string to ObjectId.
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // The attribute's value of Name represents the property name in the MongoDB collection.
        [BsonElement("FullName")]
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        public string DOB { get; set; }

        public string Email { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Username { get; set; }
    }
}