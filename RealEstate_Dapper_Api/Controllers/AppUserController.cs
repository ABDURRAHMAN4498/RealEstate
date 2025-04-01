using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;

namespace RealEstate_Dapper_Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AppUserController : ControllerBase
{
    private readonly IAppUserRepository _appUserRepository;

    public AppUserController(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    [HttpGet("GetAppUserByProductId")]
    public async Task<IActionResult> GetAppUserByProductId(int id)
    {
        
        var value = await _appUserRepository.GetAppUserByProductId(id);
        return Ok(value);
    }
}