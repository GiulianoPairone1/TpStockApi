using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TpStockApi.Services.Interfaces;

namespace TpStockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GerenteController : ControllerBase
    {
        private readonly IGerenteService _gerenteService;
        public GerenteController (IGerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }

        [HttpGet]
        public IActionResult GetAllGerentes()
        {
            string role = User.Claims.FirstOrDefault(C => C.Type == ClaimTypes.Role).Value;
            if(role=="Gerente")
            {
                return Ok(_gerenteService.GetAll());
            }
            return Forbid();
        }
    }
}
