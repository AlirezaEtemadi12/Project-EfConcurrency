using System;

namespace EfConcurrency.DataLayer.BaseClasses
{
    public interface IBaseEntity<TKey>
    {
        TKey Id { get; set; }
        DateTime CreateDateTime { get; set; }
        DateTime UpdateDateTime { get; set; }
    }
}
