using ICarros.Persistencia.Mapeamento;
using ICarros.Persistencia.Model;
using System.Data.Entity;

namespace ICarros.Persistencia.DataContext
{
    public class Contexto : DbContext
    {
        public Contexto() : base("TesteCrawler")
        {
        }

        public DbSet<Carro> Carros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new CarroMap());
        }

        public void CriarBase() {

            Database.CreateIfNotExists();
        }

        public void DropBase()
        {
            Database.Delete();
        }
    }
}
