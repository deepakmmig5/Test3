using Test3.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using Microsoft.EntityFrameworkCore;

namespace Test3.Repositories;

public interface ICentresRepositories
{
    Task<Centres> Create(Centres obj);
    List<Centres> GetCentres();
}

public class CentresRepositories : ICentresRepositories
{
    private readonly IdbContext _dbcontext;
    public CentresRepositories(IdbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<Centres> Create(Centres obj)
    {
        var collection = _dbcontext.GetCollection<Centres>(typeof(Centres).Name);
        await collection.InsertOneAsync(obj);
        return obj;
    }

    public List<Centres> GetCentres()
    {
        var collEmp = _dbcontext.GetCollection<Employees>(typeof(Employees).Name);
        var collCentre = _dbcontext.GetCollection<Centres>(typeof(Centres).Name);
        var Query =collCentre.AsQueryable()
        .GroupJoin(collEmp.AsQueryable(), x => x.CentreID, y => y.CentreID, (x, y) => new { x, y })
        .ToList()
        .Select(s => new Centres
        {
            CentreID = s.x.CentreID,
            Centre = s.x.Centre,
            State = s.x.State,
            EmployeeList = s.y.ToList<Employees>()
        }).Where(w=>(w.EmployeeList??new List<Employees>()).Count>0).ToList();
        return Query;
    }
}
