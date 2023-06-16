using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DAO.ModelsConfigs
{
    public class PurchaseOrderConfigurator : OrderBaseConfigurator<PurchaseOrder>
    {
        public override void Configure(EntityTypeBuilder<PurchaseOrder> order)
        {
            base.Configure(order);

            order.ToTable(nameof(PurchaseOrder).ToSnakeCase())
                .HasKey(t => t.Id);

            order.Property(e => e.Status)
                .HasColumnName($"{nameof(PurchaseOrder.Status).ToSnakeCase()}")
                .IsRequired();

            order.HasMany(t => t.Books)
                .WithMany(c => c.Purchases)
                .UsingEntity<PurchaseBasket>("purchase_basket",
                l => l.HasOne<BookCopy>().WithMany().HasForeignKey(e => e.BookCopyId),
                r => r.HasOne<PurchaseOrder>().WithMany().HasForeignKey(e => e.PurchaseId),
                x =>
                {
                    x.Property("PurchaseId").HasColumnName("purchase_id");
                    x.Property("BookCopyId").HasColumnName("book_copy_id");
                    x.Property("Price").HasColumnName("price");
                });
        }
    }
}