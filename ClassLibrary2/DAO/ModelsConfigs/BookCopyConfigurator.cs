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

            copy.Property(g => g.Number)
                .HasColumnName($"{nameof(BookCopy.Number).ToSnakeCase()}")
                .IsRequired();

            copy.Property(g => g.QRContent)
                .HasColumnName($"{nameof(BookCopy.QRContent).ToSnakeCase()}")
                .IsRequired();

            copy.HasOne(c => c.Source)
                .WithOne(c => c.BookCopy)
                .HasForeignKey<BookCopy>(key => key.SourceId)
                .HasConstraintName("copy_source_fk");
        }
    }
}
