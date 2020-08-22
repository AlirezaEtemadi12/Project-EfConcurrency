using System;
using System.ComponentModel.DataAnnotations;
using EfConcurrency.ServicesLayer.ViewModels.BaseViewModel;
using IGame.Services.ViewModels;

namespace EfConcurrency.ServicesLayer.ViewModels.Track
{
    public class TrackCreateViewModel : BaseCreateViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ErrorResources), ErrorMessageResourceName = "Required")]
        [MaxLength(50, ErrorMessageResourceType = typeof(ErrorResources), ErrorMessageResourceName = "MaxLen")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorResources), ErrorMessageResourceName = "Required")]
        public int Duration { get; set; }

        public Guid AlbumId { get; set; }
    }
}
