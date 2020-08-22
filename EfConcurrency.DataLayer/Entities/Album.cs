using System.Collections.Generic;
using EfConcurrency.DataLayer.Entities.BaseClasses;

namespace EfConcurrency.DataLayer.Entities
{
    public class Album : BaseEntity
    {
        public Album()
        {
            Tracks = new HashSet<Track>();
        }

        public string Name { get; set; }

        public int Year { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
