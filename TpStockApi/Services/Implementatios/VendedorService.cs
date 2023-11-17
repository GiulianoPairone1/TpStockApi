using TpStockApi.Data;
using TpStockApi.Data.Entities;
using TpStockApi.Services.Interfaces;

namespace TpStockApi.Services.Implementatios
{
    public class VendedorService:IVendedorService
    {
        private readonly ConsultaContext _context;
        public VendedorService (ConsultaContext context)
        {
            _context = context;
        }

        public List<User>GetVendedor()
        {
            return _context.Users.Where(p => p.UserType == "Vendedor").ToList();
        }
    }

}
