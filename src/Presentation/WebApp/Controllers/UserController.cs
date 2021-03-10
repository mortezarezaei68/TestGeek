using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contract.Models;
using Services.Contract;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserViewModel userViewModel)
        {
            var userId=_userService.AddUser(userViewModel);
            return Ok(userId);
        }
        [HttpPost("add-point")]
        public async Task<IActionResult> AddPoint(PointViewModel pointViewModel)
        {
            var data=await _userService.AddPoint(pointViewModel);
            return Ok(data);
        }

        [HttpGet("point/{id}")]
        public async Task<IActionResult> GetAllUserPoint(int id)
        {
            var user = await _userService.GetAllUserPoint(id);
            return Ok(user);
        }
        [HttpGet("last-point/{id}")]
        public async Task<IActionResult> GetLastPoint(int id)
        {
            var user = await _userService.GetLastPoint(id);
            return Ok(user);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateLastPointUser(PointViewModel pointViewModel)
        {
            await _userService.UpdateLastPoint(pointViewModel);
            return NoContent();
        }
    }
}