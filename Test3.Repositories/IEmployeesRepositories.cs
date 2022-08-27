namespace Test3.Repositories;

using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using Test3.Models;
public interface IEmployeesRepositories
{

   Task<Employees> Create(Employees obj);
   Task<IEnumerable<Employees>> GetEmployees();

   Task<Employees> UpdateEmployees(Employees obj);

   Task<bool> DeleteEmployees(string _EmployeeID);
}

public class EmployeesRepositories : IEmployeesRepositories
{

    private readonly IdbContext _dbcontext;

    public EmployeesRepositories(IdbContext dbcontext)
    {
        _dbcontext=dbcontext;
    }

    public async Task<Employees> Create(Employees obj)
    {
        var coll=_dbcontext.GetCollection<Employees>(typeof(Employees).Name);
        await coll.InsertOneAsync(obj);
        return obj;    
    }

    public Task<bool> DeleteEmployees(string _EmployeeID)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Employees>> GetEmployees()
    {
        var collEmp=_dbcontext.GetCollection<Employees>(typeof(Employees).Name);
        var collCentre=_dbcontext.GetCollection<Centres>(typeof(Centres).Name);
 var Query = await (from i in collEmp.AsQueryable()
            join d in collCentre.AsQueryable() on i.CentreID equals d.CentreID 
            select new Employees(){
                EmployeeID=i.EmployeeID,
                EmployeeName=i.EmployeeName,
                Gender=i.Gender,
                DateOfBirth=i.DateOfBirth,
                CentreInfo=d
            }).ToListAsync();


        return Query;
    }

    public Task<Employees> UpdateEmployees(Employees obj)
    {
        throw new NotImplementedException();
    }
}
