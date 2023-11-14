namespace TpStockApi.Data.Entities
{
    public class Vendedor :User
    {
        public ICollection<Movimiento> MovimientoDecremento { get; set; } = new List<Movimiento>();
    }
}
