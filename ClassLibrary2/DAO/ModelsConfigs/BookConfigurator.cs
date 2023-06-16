using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DAO.ModelsConfigs
{
    public class BookConfigurator : BaseEntityConfigurator<Book>
    {
        public override void Configure(EntityTypeBuilder<Book> book)
        {
            base.Configure(book);

            book.Property(b => b.Title)
                .HasColumnName($"{nameof(Book.Title).ToSnakeCase()}")
                .IsRequired();

            book.Property(b => b.ShortDesc)
                .HasColumnName($"{nameof(Book.ShortDesc).ToSnakeCase()}")
                .IsRequired();

            book.Property(b => b.LongDesc)
                .HasColumnName($"{nameof(Book.LongDesc).ToSnakeCase()}");

            book.Property(b => b.ISBN10)
                .HasColumnName($"{nameof(Book.ISBN10)}")
                .IsRequired();

            book.Property(b => b.ISBN13)
                .HasColumnName($"{nameof(Book.ISBN13)}")
                .IsRequired();

            book.Property(b => b.PagesCount)
                .HasColumnName($"{nameof(Book.PagesCount).ToSnakeCase()}")
                .IsRequired();

            book.Property(b => b.PublisherId)
                .HasColumnName($"{nameof(Book.PublisherId).ToSnakeCase()}");

            book.HasMany(b => b.Copies)
                .WithOne(c => c.Book)
                .HasForeignKey(key => key.BookId)
                .HasConstraintName("copy_book_fk");

            book.HasMany(b => b.Genres)
                .WithMany(c => c.Books);

            book.HasMany(b => b.Authors)
                .WithMany(c => c.Books);

            book.HasOne(b => b.Publisher)
                .WithMany(c => c.Books)
                .HasForeignKey(key => key.PublisherId)
                .HasConstraintName("book_publisher_id_fk");

            book.HasIndex(g => g.Title).IsUnique();
        }
    }
}
