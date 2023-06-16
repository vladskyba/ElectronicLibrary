using ElectronicLibrary.DAO.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ElectronicLibrary.Extensions;

namespace ElectronicLibrary.DAO.ModelsConfigs
{
    public class BaseEntityConfigurator<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(b => b.Id)
                .HasColumnName($"{typeof(TEntity).Name.ToSnakeCase()}_id")
                .IsRequired()
                .ValueGeneratedOnAdd();
        }
    }
}
