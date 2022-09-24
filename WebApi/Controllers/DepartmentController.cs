using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    private DepartmentService _quoteService;
    public DepartmentController(DepartmentService departmentService)
    {
        _quoteService = departmentService;
    }
  

    [HttpGet("GetDepartments")]
    public async Task<Response<List<GetDepartmentsDto>>> GetDepartments()
    {
        return await _quoteService.GetDepartments();
    }

    [HttpGet("GetDepartmentById")]
    public async Task<Response<List<GetDepartmentsDto>>> GetDepartmentById(int id)
    {
        return await _quoteService.GetDepartmentById(id);
    }


    [HttpPost("Insert")]
    public async Task<Response<Department>> Insert(Department department)
    {
        return await _quoteService.Insert(department);
    }
    [HttpPut("Update")]
    public async Task<Response<Department>> Update(Department department)
    {
        return await _quoteService.Update(department);
    }

}