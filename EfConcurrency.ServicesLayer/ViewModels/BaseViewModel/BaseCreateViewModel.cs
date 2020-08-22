using System;
using Newtonsoft.Json;

namespace EfConcurrency.ServicesLayer.ViewModels.BaseViewModel
{
    public class BaseCreateViewModel : IBaseViewModel<Guid>
    {
        [JsonIgnore]
        public Guid Id { get => Guid.NewGuid(); set { } }

        [JsonIgnore]
        public DateTime CreateDateTime => DateTime.Now;

        [JsonIgnore]
        public DateTime UpdateDateTime => DateTime.Now;
    }
}
