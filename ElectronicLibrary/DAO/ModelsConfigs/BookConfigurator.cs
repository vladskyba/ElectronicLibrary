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

            book.ToTable(nameof(Book).ToSnakeCase())
                .HasKey(t => t.Id);

            book.Property(b => b.Title)
                .HasColumnName($"{nameof(Book.Title).ToSnakeCase()}")
                .HasMaxLength(100)
                .IsRequired();

            book.Property(b => b.ShortDesc)
                .HasColumnName($"short_description")
                .HasMaxLength(1000)
                .IsRequired();

            book.Property(b => b.LongDesc)
                .HasMaxLength(5000)
                .HasColumnName($"long_description");

            book.Property(b => b.ISBN10)
                .HasMaxLength(10)
                .HasColumnName($"isbn10")
                .IsRequired();

            book.Property(b => b.ISBN13)
                .HasMaxLength(13)
                .HasColumnName($"isbn13")
                .IsRequired();

            book.Property(b => b.PagesCount)
                .HasColumnName($"{nameof(Book.PagesCount).ToSnakeCase()}")
                .IsRequired();

            book.Property(b => b.PaperCount)
                .HasColumnName($"{nameof(Book.PaperCount).ToSnakeCase()}")
                .IsRequired();

            book.Property(b => b.ElectronicCount)
                .HasColumnName($"{nameof(Book.ElectronicCount).ToSnakeCase()}")
                .IsRequired();

            book.Property(b => b.TitleImageUrl)
                .HasColumnName($"{nameof(Book.TitleImageUrl).ToSnakeCase()}")
                .HasMaxLength(255)
                .IsRequired();

            book.Property(b => b.PublisherId)
                .HasColumnName($"{nameof(Book.PublisherId).ToSnakeCase()}");

            book.HasMany(b => b.Copies)
                .WithOne(c => c.Book)
                .HasForeignKey(key => key.BookId);

            book.HasMany(b => b.Genres)
                .WithMany(c => c.Books)
                 .UsingEntity("book_genres", x =>
                 {
                     x.Property("GenresId").HasColumnName("genre_id");
                     x.Property("BooksId").HasColumnName("book_id");
                 });

            book.HasMany(b => b.Authors)
                .WithMany(c => c.Books)
                .UsingEntity("book_author", x =>
                {
                    x.Property("AuthorsId").HasColumnName("author_id");
                    x.Property("BooksId").HasColumnName("book_id");
                });

            book.HasOne(b => b.Publisher)
                .WithMany(c => c.Books)
                .HasForeignKey(key => key.PublisherId);

            //book.HasIndex(g => g.Title).IsUnique();
        }
    }
}
