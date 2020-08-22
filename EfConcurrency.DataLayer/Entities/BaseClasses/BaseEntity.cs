using System;
using EfConcurrency.DataLayer.BaseClasses;

namespace EfConcurrency.DataLayer.Entities.BaseClasses
{
    public abstract class BaseEntity : IBaseEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
