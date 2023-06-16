using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DAO.ModelsConfigs
{
    public class AuthorConfigurator : BaseEntityConfigurator<Author>
    {
        public override void Configure(EntityTypeBuilder<Author> author)
        {
            base.Configure(author);

            author.ToTable(nameof(Author).ToSnakeCase())
                .HasKey(t => t.Id);

            author.Property(a => a.Name)
                .HasColumnName($"{nameof(Author.Name).ToSnakeCase()}")
                .HasMaxLength(50)
                .IsRequired();

            author.Property(a => a.Surname)
                .HasColumnName($"{nameof(Author.Surname).ToSnakeCase()}")
                .HasMaxLength(50)
                .IsRequired();

            author.Property(a => a.Biography)
                .HasMaxLength(1000)
                .HasColumnName($"{nameof(Author.Biography).ToSnakeCase()}");

            author.Property(a => a.BirthDate)
                .HasColumnName($"{nameof(Author.BirthDate).ToSnakeCase()}");
        }
    }
}
