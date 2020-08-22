using System;
using EfConcurrency.DataLayer.Entities.BaseClasses;

namespace EfConcurrency.DataLayer.Entities
{
    public class Track: BaseEntity
    {
        public string Name { get; set; }

        public int Duration { get; set; }

        public Guid AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
