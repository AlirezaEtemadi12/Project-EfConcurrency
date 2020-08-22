using System.Data.Entity.ModelConfiguration;

namespace EfConcurrency.DataLayer.Entities.Configs
{
    public class TrackConfig : EntityTypeConfiguration<Track>
    {
        public TrackConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(50);

            HasRequired(x => x.Album)
                .WithMany(x => x.Tracks)
                .HasForeignKey(x => x.AlbumId)
                .WillCascadeOnDelete(false);
        }
    }
}
