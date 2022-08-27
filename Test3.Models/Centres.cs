using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Test3.Models;

public class Centres
{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("Id")]
        public string? CentreID { get; set; }
       
        [Required]
        [StringLength(100)]
        public string? Centre { get; set; }

        public string? State { get; set; }="";


        [NotMapped]
        public List<Employees>? EmployeeList { get; set; }
}
