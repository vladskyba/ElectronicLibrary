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
            
            author.Property(a => a.Name)
                .HasColumnName($"{nameof(Author.Name).ToSnakeCase()}")
                .IsRequired();

            author.Property(a => a.Surname)
                .HasColumnName($"{nameof(Author.Surname).ToSnakeCase()}")
                .IsRequired();

            author.Property(a => a.Biography)
                .HasColumnName($"{nameof(Author.Biography).ToSnakeCase()}");

            author.Property(a => a.BirthDate)
                .HasColumnName($"{nameof(Author.BirthDate).ToSnakeCase()}");
        }
    }
}
