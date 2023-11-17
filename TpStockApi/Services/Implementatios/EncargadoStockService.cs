using TpStockApi.Data;
using TpStockApi.Data.Entities;
using TpStockApi.Services.Interfaces;

namespace TpStockApi.Services.Implementatios
{
    public class EncargadoStockService:IEncargadoService
    {
        private readonly ConsultaContext _context;
        public EncargadoStockService(ConsultaContext context)
        {
            _context = context;
        }
        public List<User> GetEncargado()
        {
            return _context.Users.Where(p => p.UserType == "Encargado").ToList();
        }
    }
}

