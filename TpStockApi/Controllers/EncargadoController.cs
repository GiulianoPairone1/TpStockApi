using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpStockApi.Services.Interfaces;

namespace TpStockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncargadoController : ControllerBase
    {
        private readonly IEncargadoService _encarcagoService;
        public EncargadoController(IEncargadoService encarcagoService)
        {
            _encarcagoService = encarcagoService;
        }
    }
}
