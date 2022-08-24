using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Test3.Repositories;

public interface IdbContext
    {
        IMongoCollection<T> GetCollection<T>(string name); 
        IMongoCollection<BsonDocument> GetBsonCollection(string name); 
    }
public class dbContext : IdbContext
   {
       private IMongoDatabase _db { get; set; }
       private MongoClient _mongoClient { get; set; }
       public IClientSessionHandle? Session { get; set; }
       public dbContext(IOptions<Mongosettings> configuration)
       {
           _mongoClient = new MongoClient(configuration.Value.Connection);
           _db =_mongoClient.GetDatabase(configuration.Value.DatabaseName);
       }
      
       public IMongoCollection<T> GetCollection<T>(string name)
       {
           return _db.GetCollection<T>(name);
       }
       public IMongoCollection<BsonDocument> GetBsonCollection(string collection)
        {
    return _db.GetCollection<BsonDocument>(collection);
        }
   }
   public class Mongosettings
   {
       public string? Connection { get; set; }
       public string? DatabaseName { get; set; }
   }
