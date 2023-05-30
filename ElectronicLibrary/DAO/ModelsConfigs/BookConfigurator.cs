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

            book.Property(b => b.ShortDesc)
                .HasColumnName($"{nameof(Book.LongDesc).ToSnakeCase()}");

            book.Property(b => b.ISBN10)
                .HasColumnName($"{nameof(Book.ISBN10).ToSnakeCase()}")
                .IsRequired();

            book.Property(b => b.ISBN13)
                .HasColumnName($"{nameof(Book.ISBN13).ToSnakeCase()}")
                .IsRequired();

            book.Property(b => b.PagesCount)
                .HasColumnName($"{nameof(Book.PagesCount).ToSnakeCase()}")
                .IsRequired();
            
            book.HasMany(b => b.Copies)
                .WithOne(c => c.Book)
                .HasForeignKey(key => key.BookId)
                .HasConstraintName("copy_book_fk");

            book.HasMany(b => b.Genres)
                .WithOne(c => c.Book)
                .HasForeignKey(key => key.BookId)
                .HasConstraintName("genre_book_fk");

            book.HasMany(b => b.Authors)
                .WithOne(c => c.Book)
                .HasForeignKey(key => key.BookId)
                .HasConstraintName("author_book_fk");
        }
    }
}
