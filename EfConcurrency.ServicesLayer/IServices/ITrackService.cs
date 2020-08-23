using System;
using System.Collections.Generic;
using EfConcurrency.ServicesLayer.ViewModels.Track;

namespace EfConcurrency.ServicesLayer.IServices
{
    public interface ITrackService : IApplicationService, IDisposable
    {
        TrackViewModel Detail(Guid id);

        List<TrackViewModel> List();

        TrackViewModel Create(TrackCreateViewModel trackCreateViewModel);

        TrackViewModel Update(TrackUpdateViewModel trackViewModel);

        bool Delete(TrackViewModel trackViewModel);
    }
}
