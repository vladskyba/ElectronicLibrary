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

            genre.Property(g => g.Name)
                .HasColumnName($"{nameof(Genre.Name).ToSnakeCase()}")
                .IsRequired();

            genre.Property(g => g.Name)
                .HasColumnName($"{nameof(Genre.Description).ToSnakeCase()}")
                .IsRequired();
        }
    }
}
