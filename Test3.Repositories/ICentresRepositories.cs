using Test3.Models;

namespace Test3.Repositories;

public interface ICentresRepositories
{
    Task<Centres> Create(Centres obj);
}

public class CentresRepositories : ICentresRepositories
{
    private readonly IdbContext _dbcontext;
    public CentresRepositories(IdbContext dbcontext)
    {
        _dbcontext=dbcontext;
    }

    public async Task<Centres> Create(Centres obj)
    {
        var collection=_dbcontext.GetCollection<Centres>(typeof(Centres).Name);
        await collection.InsertOneAsync(obj);
        return obj;
    }
}
