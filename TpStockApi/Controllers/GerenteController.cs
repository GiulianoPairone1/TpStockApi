using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TpStockApi.Services.Interfaces;
using TpStockApi.Data.Entities;
using TpStockApi.Data.Models;
using TpStockApi.Services.Implementatios;
using System.Linq;

namespace TpStockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GerenteController : ControllerBase
    {
        private readonly IGerenteService _gerenteService;
        private readonly IUserService _userService;


        public GerenteController (IGerenteService gerenteService, IUserService userService)
        {
            _gerenteService = gerenteService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateGerente([FromBody] GerentePosDto dto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if(role=="Gerente")
            {
                var gerente = new Gerente()
                {
                    Email = dto.Email,
                    FullName = dto.FullName,
                    Password = dto.Password,
                    UserName = dto.UserName,
                    UserType = "Gerente",
                };
                int id = _userService.CreateUser(gerente);
                return Ok(id);
            }
            return Forbid();

        }

        [HttpPut]
        public IActionResult UpdateGeremte ([FromBody] GerenteUpdateDto updateGerente)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Gerente")
            {
                Gerente gerenteUpdate = new Gerente()
                {
                    Id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                    UserName = User.Claims.FirstOrDefault(c => c.Type.Contains("username")).Value,
                    FullName = updateGerente.FullName,
                    Password = updateGerente.Password,
                    UserType = "Gerente",
                };
                _userService.UpdateUser(gerenteUpdate);
                return Ok();
            }
            return Forbid();
        }

        [HttpGet]
        public IActionResult GetGerentes()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            User userLogged = _userService.GetUserByEmail(User.Claims.FirstOrDefault(c=> c.Type == ClaimTypes.Email).Value);
            if (role == "Gerente" && userLogged.State)
            {

                return Ok(_gerenteService.GetGerente());
            }
            return Forbid();
        }
    }
    
}
