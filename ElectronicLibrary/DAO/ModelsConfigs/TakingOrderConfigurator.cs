using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DAO.ModelsConfigs
{
    public class TakingOrderConfigurator : OrderBaseConfigurator<TakingOrder>
    {
        public override void Configure(EntityTypeBuilder<TakingOrder> takingOrder)
        {
            base.Configure(takingOrder);

            takingOrder.ToTable(nameof(TakingOrder).ToSnakeCase())
                .HasKey(t => t.Id);

            takingOrder.Property(e => e.Start)
                .HasColumnName($"{nameof(TakingOrder.Start).ToSnakeCase()}")
                .IsRequired();

            takingOrder.Property(e => e.Stop)
                .HasColumnName($"{nameof(TakingOrder.Stop).ToSnakeCase()}")
                .IsRequired();

            takingOrder.Property(e => e.Status)
                .HasColumnName($"{nameof(TakingOrder.Status).ToSnakeCase()}")
                .IsRequired();

            takingOrder.HasMany(t => t.Books)
                .WithMany(c => c.Takings)
                .UsingEntity("taking_book", x =>
                {
                    x.Property("TakingsId").HasColumnName("taking_id");
                    x.Property("BooksId").HasColumnName("book_id");
                }); ;
        }
    }
}
