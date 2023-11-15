using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpStockApi.Services.Interfaces;

namespace TpStockApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorService _vendedorService;
        public VendedorController (IVendedorService vendedorService)
        {
            _vendedorService = vendedorService;
        }
    }
}
