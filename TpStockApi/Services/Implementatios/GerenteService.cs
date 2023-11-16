using TpStockApi.Data;
using TpStockApi.Data.Entities;
using TpStockApi.Services.Interfaces;

namespace TpStockApi.Services.Implementatios
{
    public class GerenteService:IGerenteService
    {
        private readonly ConsultaContext _context;
        public GerenteService(ConsultaContext context)
        {
            _context = context;
        }
        public List<Gerente>GetAll()
        {
            return _context.Gerentes.ToList();
        }
    }
}
