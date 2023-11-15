using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpStockApi.Services.Interfaces;

namespace TpStockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerenteController : ControllerBase
    {
        private readonly IGerenteService _gerenteService;
        public GerenteController (IGerenteService gerenteService)
        {
            _gerenteService = gerenteService;
        }
    }
}
