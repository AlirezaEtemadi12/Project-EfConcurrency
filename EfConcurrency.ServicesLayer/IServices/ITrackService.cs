using System;
using System.Collections.Generic;
using EfConcurrency.ServicesLayer.ViewModels.Track;

namespace EfConcurrency.ServicesLayer.IServices
{
    public interface ITrackService : IApplicationService, IDisposable
    {
        TrackViewModel Detail(Guid id);

        List<TrackViewModel> List();

        TrackViewModel Add(TrackCreateViewModel trackCreateViewModel);

        TrackViewModel Update(TrackViewModel trackViewModel);

        bool Delete(TrackViewModel trackViewModel);
    }
}
