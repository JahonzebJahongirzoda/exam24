using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Services;
using Npgsql;
using Dapper;
using Domain.Wrapper;
using Infrastructure.DataContext;

public class ManagerService
{
    private DataContext _context;

    public ManagerService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetDto>>> Get()
    {
        await using var connection = _context.CreateConnection();
        var sql = " SELECT  employee.Id as  ManagerId,CONCAT(FirstName,LastName) as ManagerFullName, department.Id as DepartmentId, department.Name as DepartmentName,department_manager.FromDate as FromDate,department_manager.ToDate as ToDate FROM department JOIN department_manager ON department.id = department_manager.departmentid JOIN employee ON department_manager.employeeid = employee.id  " ;
        var result = await connection.QueryAsync<GetDto>(sql);
        return new Response<List<GetDto>>(result.ToList());
    }

    

    public async Task<Response<Department_manager>> Insert(Department_manager departmentmanager)
    {
        using var connection = _context.CreateConnection();
        try
        {
            var sql = $"insert into Department_manager (FromDate) values (@FromDate) returning EmployeeId;";
            var result =
                await connection.ExecuteScalarAsync<int>(sql,
                    new { Department_manager.FromDate});
            Department_manager.EmployeeId = result;
            return new Response<Department_manager>(departmentmanager);
        }
        catch (Exception ex)
        {
            return new Response<Department_manager>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    
    
    
    
    
}