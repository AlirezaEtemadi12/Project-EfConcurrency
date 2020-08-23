using System;
using System.Collections.Generic;
using EfConcurrency.ServicesLayer.ViewModels.Album;

namespace EfConcurrency.ServicesLayer.IServices
{
    public interface IAlbumService : IApplicationService, IDisposable
    {
        AlbumViewModel Detail(Guid id);

        List<AlbumViewModel> List();

        AlbumViewModel Create(AlbumCreateViewModel albumCreateViewModel);

        AlbumViewModel Update(AlbumUpdateViewModel albumViewModel);

        bool Delete(AlbumViewModel albumViewModel);

        #region ### Safe methods ###
        AlbumViewModel DetailSafely(Guid id);

        List<AlbumViewModel> ListSafely();

        AlbumViewModel AddSafely(AlbumCreateViewModel albumCreateViewModel);

        AlbumViewModel UpdateSafely(AlbumUpdateViewModel albumViewModel);

        bool DeleteSafely(AlbumViewModel albumViewModel);
        #endregion
    }
}
