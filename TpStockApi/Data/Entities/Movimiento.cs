using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TpStockApi.Data.Entities
{
    public class Movimiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Gerente> Gerente { get; set; } = new List<Gerente>();
        public ICollection<EncargadoStock> EncargadoStock { get; set; } = new List<EncargadoStock>();
        public ICollection<Vendedor> Vendedores { get; set; }= new List<Vendedor>();
    }
}
