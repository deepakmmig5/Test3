using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Test3.Models;

public class Employees
{
     [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("Id")]
        public string? EmployeeID { get; set; }


        
        [Required]
        [StringLength(10)]
        public string? EmployeeName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }

        public string? State { get; set; }
        public string? City { get; set; }   
        public string? Area { get; set; }

        public string? Pincode { get; set; }

        public DateTime CreatedDate { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? CentreID{get;set;}
        [NotMapped]
        public Centres? CentreInfo { get; set; }
        
        
}
