using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PayLess.Models;

namespace PayLess.Data.Mappings
{
    public class EstoqueLojaMap : IEntityTypeConfiguration<EstoqueLoja>
    {
        public void Configure(EntityTypeBuilder<EstoqueLoja> builder)
        {
            builder.ToTable("EstoqueLoja");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Loja)
                .WithMany(y=>y.Estoque)
                .HasForeignKey(z=>z.LojaId);

            builder.HasOne(e => e.Produto)
            .WithMany(p => p.Estoque)
            .HasForeignKey(e => e.ProdutoId);

        }
    }
}
