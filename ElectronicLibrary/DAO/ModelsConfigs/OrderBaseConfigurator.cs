using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DAO.ModelsConfigs
{
    public class OrderBaseConfigurator<TEntity> : BaseEntityConfigurator<TEntity>
        where TEntity : OrderBase
    {
        public override void Configure(EntityTypeBuilder<TEntity> orderBase)
        {
            base.Configure(orderBase);

            orderBase.Property(e => e.Phone)
                .HasColumnName($"{nameof(OrderBase.Phone).ToSnakeCase()}")
                .HasMaxLength(20)
                .IsRequired();

            orderBase.Property(e => e.Email)
                .HasColumnName($"{nameof(OrderBase.Email).ToSnakeCase()}")
                .HasMaxLength(50)
                .IsRequired();

            orderBase.Property(e => e.CreatedById)
                .HasColumnName($"{nameof(OrderBase.CreatedById).ToSnakeCase()}")
                .IsRequired();

            orderBase.Property(e => e.CreatedForId)
                .HasColumnName($"{nameof(OrderBase.CreatedForId).ToSnakeCase()}")
                .IsRequired();
        }
    }
}
