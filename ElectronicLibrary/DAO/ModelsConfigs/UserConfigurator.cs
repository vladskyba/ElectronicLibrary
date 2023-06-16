using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DAO.ModelsConfigs
{
    public class UserConfigurator : BaseEntityConfigurator<User>
    {
        public override void Configure(EntityTypeBuilder<User> user)
        {
            base.Configure(user);

            user.ToTable(nameof(User).ToSnakeCase())
                .HasKey(t => t.Id);

            user.Property(e => e.Email)
                .HasColumnName($"{nameof(User.Email).ToSnakeCase()}")
                .IsRequired();

            user.Property(e => e.PasswordHash)
                .HasColumnName($"{nameof(User.PasswordHash).ToSnakeCase()}")
                .IsRequired();

            user.Property(e => e.Phone)
                .HasColumnName($"{nameof(User.Phone).ToSnakeCase()}")
                .HasMaxLength(20);

            user.Property(e => e.FirstName)
                .HasColumnName($"{nameof(User.FirstName).ToSnakeCase()}")
                .HasMaxLength(50)
                .IsRequired();

            user.Property(e => e.LastName)
                .HasColumnName($"{nameof(User.LastName).ToSnakeCase()}")
                .HasMaxLength(50);

            user.Property(e => e.Role)
                .HasColumnName($"{nameof(User.Role).ToSnakeCase()}")
                .IsRequired();

            user.Property(e => e.Bithday)
                .HasColumnName($"{nameof(User.Bithday).ToSnakeCase()}");

            user.HasMany(u => u.UserTakings)
                .WithOne(t => t.CreatedFor)
                .HasForeignKey(t => t.CreatedForId);

            user.HasMany(u => u.CreatedTakings)
                .WithOne(t => t.CreatedBy)
                .HasForeignKey(t => t.CreatedById);

            user.HasMany(u => u.CreatedPurchases)
                .WithOne(t => t.CreatedBy)
                .HasForeignKey(t => t.CreatedById);

            user.HasMany(u => u.UserPurchases)
                .WithOne(t => t.CreatedFor)
                .HasForeignKey(t => t.CreatedForId);

            user.HasMany(u => u.Discounts)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            user.HasIndex(g => g.Email).IsUnique();
        }
    }
}
