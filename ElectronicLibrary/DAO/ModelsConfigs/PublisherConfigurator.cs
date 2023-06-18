using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DAO.ModelsConfigs
{
    public class PublisherConfigurator : BaseEntityConfigurator<Publisher>
    {
        public override void Configure(EntityTypeBuilder<Publisher> publisher)
        {
            base.Configure(publisher);

            publisher.ToTable(nameof(Publisher).ToSnakeCase())
                .HasKey(t => t.Id);

            publisher.Property(g => g.Name)
                .HasColumnName($"{nameof(Publisher.Name).ToSnakeCase()}")
                .HasMaxLength(50)
                .IsRequired();

            publisher.Property(g => g.WebsiteUrl)
                .HasColumnName($"{nameof(Publisher.WebsiteUrl).ToSnakeCase()}")
                .HasMaxLength(255)
                .IsRequired();

            //publisher.HasIndex(g => g.Name).IsUnique();
        }
    }
}
