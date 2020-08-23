using AutoMapper;
using EfConcurrency.DataLayer.Entities;
using EfConcurrency.ServicesLayer.ViewModels.Track;

namespace EfConcurrency.ServicesLayer.MapperProfiles
{
    public class TrackProfile : Profile
    {
        public TrackProfile()
        {
            CreateMap<TrackViewModel, Track>().ReverseMap();
            CreateMap<TrackCreateViewModel, Track>();
            CreateMap<TrackUpdateViewModel, Track>();
        }
    }
}
