using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(CreateLoginDto createLoginDto)
        {
            string query = $"select * from AppUser where UserName='{createLoginDto.UserName}' and Password='{createLoginDto.Password}';";
            string query2 = $"select UserId from AppUser where UserName='{createLoginDto.UserName}' and Password='{createLoginDto.Password}';";
            using (var connection = _context.CreaConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query);
                int values2 = await connection.QueryFirstAsync<int>(query2);
                if (values is not null)
                {
                    GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                    model.UserName = values.UserName;
                    model.Id = values2;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized("User Not Found");
                }
            }
             
        }
    }
}
