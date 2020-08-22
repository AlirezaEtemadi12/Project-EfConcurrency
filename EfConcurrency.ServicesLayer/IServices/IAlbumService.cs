using System;
using System.Collections.Generic;
using EfConcurrency.ServicesLayer.ViewModels.Album;

namespace EfConcurrency.ServicesLayer.IServices
{
    public interface IAlbumService : IApplicationService, IDisposable
    {
        AlbumViewModel Detail(Guid id);

        AlbumViewModel DetailSafely(Guid id);

        List<AlbumViewModel> List();

        AlbumViewModel Add(AlbumCreateViewModel albumCreateViewModel);

        AlbumViewModel Update(AlbumViewModel albumViewModel);

        AlbumViewModel UpdateSafely(AlbumViewModel albumViewModel);

        bool Delete(AlbumViewModel albumViewModel);
    }
}
