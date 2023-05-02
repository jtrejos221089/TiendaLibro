using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Data.Configuration;

public class LibroConfiguration:IEntityTypeConfiguration<Libro>
{    
    public void Configure(EntityTypeBuilder<Libro> builder)
    {
        builder.ToTable("Libros");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.codigo_Libro).IsRequired().HasMaxLength(2);
        builder.Property(p => p.nombre_Libro).IsRequired();
        builder.Property(p => p.nombre_Empresa).IsRequired().HasMaxLength(30);
        builder.Property(p => p.descripcion_Libro).IsRequired();
        builder.Property(p => p.estado_Libro).IsRequired();
        builder.Property(p => p.precio_Libro).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasOne(p => p.Cliente).WithMany(p => p.libros_Cliente).HasForeignKey(p => p.ClienteId);
    }
}
