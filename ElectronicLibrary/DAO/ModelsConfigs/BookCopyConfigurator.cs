using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DAO.ModelsConfigs
{
    public class BookCopyConfigurator : BaseEntityConfigurator<BookCopy>
    {
        public override void Configure(EntityTypeBuilder<BookCopy> copy)
        {
            base.Configure(copy);

            copy.ToTable(nameof(BookCopy).ToSnakeCase())
                .HasKey(t => t.Id);

            copy.Property(g => g.Number)
                .HasColumnName($"copy_number");

            copy.Property(g => g.QRUrl)
                .HasColumnName($"qr_url");

            copy.Property(g => g.Type)
                .HasColumnName($"copy_type")
                .IsRequired();

            copy.Property(g => g.Price)
                .HasColumnName($"price")
                .IsRequired();

            copy.Property(g => g.Condition)
                .HasColumnName($"physical_condition");

            copy.Property(g => g.SourceId)
                .HasColumnName($"{nameof(BookCopy.SourceId).ToSnakeCase()}");

            copy.Property(g => g.BookId)
                .HasColumnName($"{nameof(BookCopy.BookId).ToSnakeCase()}")
                .IsRequired();

            copy.HasOne(c => c.Source)
                .WithOne(c => c.BookCopy)
                .HasForeignKey<BookCopy>(key => key.SourceId)
                .IsRequired(false);
        }
    }
}
