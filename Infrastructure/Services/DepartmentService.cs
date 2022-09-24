using Domain.Entities;

namespace Infrastructure.Services;
using Npgsql;
using Dapper;
using Domain.Wrapper;
using Infrastructure.DataContext;

public class DepartmentService
{
    private DataContext _context;

    public DepartmentService(DataContext context)
    {
        _context = context;
    }

    public async Task<Response<List<GetDepartmentsDto>>> GetDepartments()
    {
        await using var connection = _context.CreateConnection();
        var sql = "SELECT department.Id , department.Name , employee.Id as Managerid, CONCAT(FirstName,LastName) as ManagerFullName FROM department JOIN department_employee ON department.id = department_employee.departmentid JOIN employee ON department_employee.employeeid = employee.id;    ";
        var result = await connection.QueryAsync<GetDepartmentsDto>(sql);
        return new Response<List<GetDepartmentsDto>>(result.ToList());
    }

    public async Task<Response<List<GetDepartmentsDto>>> GetDepartmentById(int id)
    {
        await using var connection = _context.CreateConnection();
        var sql = $"SELECT department.Id , department.Name , employee.Id as Managerid, CONCAT(FirstName,LastName) as ManagerFullName FROM department JOIN department_employee ON department.id = department_employee.departmentid JOIN employee ON department_employee.employeeid = employee.id   where Department.id={id};";
        var result = await connection.QueryAsync<GetDepartmentsDto>(sql);
        return new Response<List<GetDepartmentsDto>>(result.ToList());
    }

    public async Task<Response<Department>> Insert(Department department)
    {
        using var connection = _context.CreateConnection();
        try
        {
            var sql = $"insert into Department (Name) values (@Name) returning id;";
            var result =
                await connection.ExecuteScalarAsync<int>(sql,
                    new { Department.Name});
            Department.Id = result;
            return new Response<Department>(department);
        }
        catch (Exception ex)
        {
            return new Response<Department>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
    
    
    
    
    public async Task<Response<Department>> Update(Department department)
    {
        using var connection = _context.CreateConnection();
        try
        {
            var sql = $"insert into Department (Name) values (@Name) returning id;";
            var result = await connection.ExecuteScalarAsync<int>(sql,
                    new {Department.Name});
            return new Response<Department>(department);
        }
        catch (Exception ex)
        {
            return new Response<Department>(System.Net.HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}