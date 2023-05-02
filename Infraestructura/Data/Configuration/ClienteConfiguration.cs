using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.codigo_Cliente).IsRequired().HasMaxLength(5);
        builder.Property(p => p.nombre_Cliente).IsRequired();
        builder.Property(p => p.cedula_Cliente).IsRequired().HasMaxLength(9);
        builder.Property(p => p.fn_Cliente).IsRequired();
    }
}
