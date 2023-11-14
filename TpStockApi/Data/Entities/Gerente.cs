namespace TpStockApi.Data.Entities
{
    public class Gerente:User
    {
        public ICollection<Movimiento> MovimientoIncremento { get; set; }=new List<Movimiento>();
    }
}
