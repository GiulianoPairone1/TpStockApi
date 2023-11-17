using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TpStockApi.Services.Interfaces;
using TpStockApi.Data.Entities;
using TpStockApi.Data.Models;

namespace TpStockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorService _vendedorService;
        private readonly IUserService _userService;
        public VendedorController (IVendedorService vendedorService, IUserService userService)
        {
            _vendedorService = vendedorService;
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateVendedor([FromBody] VendedorPosDto dto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Vendedor")
            {
                var vendedor = new Vendedor()
                {
                    Email = dto.Email,
                    FullName = dto.FullName,
                    Password = dto.Password,
                    UserName = dto.UserName,
                    UserType = "Vendedor",
                };
                int id = _userService.CreateUser(vendedor);
                return Ok(id);
            }
            return Forbid();

        }

        [HttpGet]
        public IActionResult GetVendedor()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            User userLogged = _userService.GetUserByEmail(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value);
            if (role == "Vendedor" && userLogged.State)
            {

                return Ok(_vendedorService.GetVendedor());
            }
            return Forbid();
        }
        [HttpPut]
        public IActionResult UpdateVendedor([FromBody] VendedorUpdateDto updateVendedor)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Gerente")
            {
                Vendedor vendedorUpdate = new Vendedor()
                {
                    Id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                    UserName = User.Claims.FirstOrDefault(c => c.Type.Contains("username")).Value,
                    FullName = updateVendedor.FullName,
                    Password = updateVendedor.Password,
                    UserType = "Vendedor",
                };
                _userService.UpdateUser(vendedorUpdate);
                return Ok();
            }
            return Forbid();
        }

    }
}
