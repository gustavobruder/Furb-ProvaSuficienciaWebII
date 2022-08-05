using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prova.Suficiencia.Web.Entities;

namespace Prova.Suficiencia.Web.Database.Mappings
{
    public class ComandaMapping : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.ToTable("comandas");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id").IsRequired();
            builder.Property(x => x.IdUsuario).HasColumnName("nome_usuario").IsRequired();
            builder.Property(x => x.NomeUsuario).HasColumnName("nome_usuario").IsRequired();
            builder.Property(x => x.TelefoneUsuario).HasColumnName("telefone_usuario").IsRequired();

            builder
                .HasMany(x => x.Produtos)
                .WithOne(x => x.Comanda)
                .HasForeignKey(x => x.IdComanda)
                .HasPrincipalKey(x => x.Id);
        }
    }
}