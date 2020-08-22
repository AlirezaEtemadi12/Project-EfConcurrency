using AutoMapper;
using EfConcurrency.DataLayer.Entities;
using EfConcurrency.ServicesLayer.ViewModels.Album;

namespace EfConcurrency.ServicesLayer.MapperProfiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<Album, AlbumViewModel>()
                .ReverseMap();
            CreateMap<AlbumCreateViewModel, Album>();
            CreateMap<AlbumEditViewModel, Album>();
        }
    }
}
