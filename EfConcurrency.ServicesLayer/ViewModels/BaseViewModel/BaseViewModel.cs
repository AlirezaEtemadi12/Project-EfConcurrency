using System;

namespace EfConcurrency.ServicesLayer.ViewModels.BaseViewModel
{
    public class BaseViewModel : IBaseViewModel<Guid>
    {
        public Guid Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime UpdateDateTime { get; set; }
    }
}
