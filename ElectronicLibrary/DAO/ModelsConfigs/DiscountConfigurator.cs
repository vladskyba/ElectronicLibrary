using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DAO.ModelsConfigs
{
    public class DiscountConfigurator : BaseEntityConfigurator<Discount>
    {
        public override void Configure(EntityTypeBuilder<Discount> discount)
        {
            base.Configure(discount);

            discount.ToTable(nameof(Discount).ToSnakeCase())
                .HasKey(t => t.Id);

            discount.Property(e => e.Start)
                .HasColumnName($"{nameof(Discount.Start).ToSnakeCase()}")
                .IsRequired();

            discount.Property(e => e.Stop)
                .HasColumnName($"{nameof(Discount.Stop).ToSnakeCase()}")
                .IsRequired();

            discount.Property(e => e.SentDatetime)
                .HasColumnName($"{nameof(Discount.SentDatetime).ToSnakeCase()}");

            discount.Property(e => e.IsSent)
                .HasColumnName($"{nameof(Discount.IsSent).ToSnakeCase()}")
                .IsRequired();

            discount.Property(e => e.EmailContent)
                .HasColumnName($"{nameof(Discount.EmailContent).ToSnakeCase()}")
                .HasMaxLength(500)
                .IsRequired();

            discount.Property(e => e.UserId)
                .HasColumnName($"{nameof(Discount.UserId).ToSnakeCase()}")
                .IsRequired();

            discount.Property(e => e.Percent)
                .HasColumnName($"{nameof(Discount.Percent).ToSnakeCase()}")
                .IsRequired();

            discount.HasMany(t => t.Books)
                .WithMany(c => c.Discounts)
                .UsingEntity("discount_book", x =>
                {
                    x.Property("DiscountsId").HasColumnName("discount_id");
                    x.Property("BooksId").HasColumnName("book_id");
                });
        }
    }
}
