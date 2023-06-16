using ElectronicLibrary.DAO.Models;
using ElectronicLibrary.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ElectronicLibrary.DAO.ModelsConfigs
{
    public class ElectronicSourceConfigurator : BaseEntityConfigurator<ElectronicSource> 
    {
        public override void Configure(EntityTypeBuilder<ElectronicSource> source)
        {
            base.Configure(source);

            source.Property(s => s.Path)
                .HasColumnName($"{nameof(ElectronicSource.Path).ToSnakeCase()}")
                .IsRequired();

            source.Property(s => s.Size)
                .HasColumnName($"{nameof(ElectronicSource.Size).ToSnakeCase()}")
                .IsRequired();

            source.Property(s => s.UploadDatetime)
                .HasColumnName($"{nameof(ElectronicSource.UploadDatetime).ToSnakeCase()}")
                .IsRequired();
        }
    }
}
