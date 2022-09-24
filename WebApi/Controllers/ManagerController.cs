using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagerController : ControllerBase
{
    private ManagerService _quoteService;
    public ManagerController(ManagerService managerService)
    {
        _quoteService = managerService;
    }
  

    [HttpGet("Get")]
    public async Task<Response<List<GetDto>>> Get()
    {
        return await _quoteService.Get();
    }

   


    [HttpPost("Insert")]
    public async Task<Response<Department_manager>> Insert(Department_manager departmentmanager)
    {
        return await _quoteService.Insert(departmentmanager);
    }
  

}