using AutoMapper;
using EfConcurrency.ServicesLayer.MapperProfiles;

namespace EfConcurrency.ServicesLayer.Configs
{
    public static class AutoMapperConfig
    {
        public static void RegisterAutoMapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(AlbumProfile).Assembly));
        }
    }
}
