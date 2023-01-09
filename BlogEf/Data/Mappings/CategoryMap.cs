using BlogEf.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogEf.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Tabela
            builder.ToTable("Category");
            //Chave Primaria
            builder.HasKey(x => x.Id);
            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(); //Identity(1,1)

            //Propriedades
            builder.Property(x => x.Name)
                .IsRequired() //NotNull
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);
            
            builder.Property(x => x.Slug)
                .IsRequired() //NotNull
                .HasColumnName("Slug")
                .HasColumnType("VARCHAR")
                .HasMaxLength(80);
            
            //Indices
            builder.HasIndex(x => x.Slug, "IX_Category_Slug")
                .IsUnique();
        }
    }
}