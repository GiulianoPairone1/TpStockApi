namespace TpStockApi.Data.Entities
{
    public class EncargadoStock:User
    {
        public ICollection<Movimiento> Movimientos { get; set; } = new List<Movimiento>();
    }
}
