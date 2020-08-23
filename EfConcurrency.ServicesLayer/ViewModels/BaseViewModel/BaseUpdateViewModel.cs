using System;
using System.ComponentModel.DataAnnotations;
using IGame.Services.ViewModels;
using Newtonsoft.Json;

namespace EfConcurrency.ServicesLayer.ViewModels.BaseViewModel
{
    public class BaseUpdateViewModel : IBaseViewModel<Guid>
    {
        [Required(ErrorMessageResourceType = typeof(ErrorResources), ErrorMessageResourceName = "Required")]
        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime UpdateDateTime => DateTime.Now;
    }
}
