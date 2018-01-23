using ICarros.Persistencia.Model;
using System.Data.Entity.ModelConfiguration;

namespace ICarros.Persistencia.Mapeamento
{
    public class CarroMap : EntityTypeConfiguration<Carro>
    {
        public CarroMap()
        {
            ToTable("Carro");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasColumnType("varchar").HasMaxLength(80);
            Property(x => x.Km).HasColumnType("varchar").HasMaxLength(8);
            Property(x => x.Cor).HasColumnType("varchar").HasMaxLength(20);
            Property(x => x.Ano).HasColumnType("varchar").HasMaxLength(9);
            Property(x => x.Cambio).HasColumnType("varchar").HasMaxLength(20);
        }
    }
}
