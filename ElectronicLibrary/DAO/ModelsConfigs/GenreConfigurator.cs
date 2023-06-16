using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DAO.ModelsConfigs
{
    public class GenreConfigurator : BaseEntityConfigurator<Genre>
    {
        public override void Configure(EntityTypeBuilder<Genre> genre)
        {
            base.Configure(genre);

            genre.ToTable(nameof(Genre).ToSnakeCase())
                .HasKey(t => t.Id);

            genre.Property(g => g.Name)
                .HasColumnName($"{nameof(Genre.Name).ToSnakeCase()}")
                .HasMaxLength(50)
                .IsRequired();

            genre.Property(g => g.Description)
                .HasColumnName($"{nameof(Genre.Description).ToSnakeCase()}")
                .HasMaxLength(500)
                .IsRequired();

            genre.HasIndex(g => g.Description).IsUnique();
        }
    }
}
