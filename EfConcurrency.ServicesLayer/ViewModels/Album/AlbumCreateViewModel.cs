using System.ComponentModel.DataAnnotations;
using EfConcurrency.ServicesLayer.ViewModels.BaseViewModel;
using IGame.Services.ViewModels;

namespace EfConcurrency.ServicesLayer.ViewModels.Album
{
    public class AlbumCreateViewModel : BaseCreateViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ErrorResources), ErrorMessageResourceName = "Required")]
        [MaxLength(50, ErrorMessageResourceType = typeof(ErrorResources), ErrorMessageResourceName = "MaxLen")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(ErrorResources), ErrorMessageResourceName = "Required")]
        public int Year { get; set; }
    }
}
