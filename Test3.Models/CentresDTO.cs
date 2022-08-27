using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Test3.Models;

public class CentresDTO
{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("Id")]
        public string? CentreID { get; set; }
       
        [Required]
        [StringLength(100)]
        public string? CentreName { get; set; }

        public string? StateName { get; set; }="";
}
