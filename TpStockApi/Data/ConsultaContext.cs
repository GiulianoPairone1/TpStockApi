using TpStockApi.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace TpStockApi.Data
{
    public class ConsultaContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<EncargadoStock> EncargadoStocks { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        
        public ConsultaContext (DbContextOptions<ConsultaContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);
            modelBuilder.Entity<Gerente>().HasData(
                new Gerente
                {
                    FullName = "Micaela Caissno",
                    Email = "MicaelaCassino@gmail.com",
                    UserName = "M_Cassino",
                    Password = "123123",
                    Id = 1
                }
                );
            modelBuilder.Entity<EncargadoStock>().HasData(
                new EncargadoStock
                {
                    FullName = "Emilio Cerro",
                    Email = "EmilioCerro@gmail.com",
                    UserName = "E_Cerro",
                    Password = "321321",
                    Id = 2
                }
                );
            modelBuilder.Entity<Vendedor>().HasData(

                new Vendedor
                {
                    FullName = "Valentin Pairone",
                    Email = "ValentinPAirone@gmail.com",
                    UserName = "V_Pairone",
                    Password = "123456",
                    Id = 3
                },
                new Vendedor
                {
                    FullName = "Mateo Pairone",
                    Email = "MateoPAirone@gmail.com",
                    UserName = "M_Pairone",
                    Password = "654321",
                    Id = 4
                }
                );
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    NombreProducto = "Leche",
                    Descripcion = "Leche larga vida",
                    Id = 1,
                },
                new Producto
                {
                    NombreProducto = "Arroz",
                    Descripcion = "Arroz yamani",
                    Id = 2,
                },
                new Producto
                {
                    NombreProducto = "Harina",
                    Descripcion = "harina luedante",
                    Id = 3,
                }
                );
        }

    }
}
