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

            source.ToTable(nameof(ElectronicSource).ToSnakeCase())
                .HasKey(t => t.Id);

            source.Property(s => s.FilePath)
                .HasColumnName($"{nameof(ElectronicSource.FilePath).ToSnakeCase()}")
                .IsRequired();

            source.Property(s => s.FileName)
                .HasColumnName($"{nameof(ElectronicSource.FileName).ToSnakeCase()}")
                .IsRequired();

            source.Property(s => s.FileSize)
                .HasColumnName($"{nameof(ElectronicSource.FileSize).ToSnakeCase()}")
                .IsRequired();

            source.Property(s => s.UploadDatetime)
                .HasColumnName($"{nameof(ElectronicSource.UploadDatetime).ToSnakeCase()}")
                .IsRequired();
        }
    }
}
