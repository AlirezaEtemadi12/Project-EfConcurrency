
using System.Data.Entity.ModelConfiguration;

namespace EfConcurrency.DataLayer.Entities.Configs
{
    public class AlbumConfig : EntityTypeConfiguration<Album>
    {
        public AlbumConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
