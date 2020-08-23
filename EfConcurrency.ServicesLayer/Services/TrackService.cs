using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using EfConcurrency.DataLayer.Context;
using EfConcurrency.DataLayer.Entities;
using EfConcurrency.ServicesLayer.IServices;
using EfConcurrency.ServicesLayer.ViewModels.Track;

namespace EfConcurrency.ServicesLayer.Services
{
    public class TrackService : ITrackService
    {
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<Track> _tracks;

        public TrackService(IUnitOfWork uow)
        {
            _uow = uow;
            _tracks = _uow.Set<Track>();
        }

        public TrackViewModel Detail(Guid id)
        {
            return _tracks
                .Where(current => current.Id == id)
                .AsNoTracking()
                .AsEnumerable()
                .Select(Mapper.Map<TrackViewModel>)
                .FirstOrDefault();
        }

        public TrackViewModel DetailSafely(Guid id)
        {
            return _uow.ExecuteSafely(() => Detail(id));
        }

        public List<TrackViewModel> List()
        {
            return _tracks
                .AsNoTracking()
                .AsEnumerable()
                .Select(Mapper.Map<TrackViewModel>)
                .ToList();
        }

        public TrackViewModel Create(TrackCreateViewModel trackCreateViewModel)
        {
            var track = Mapper.Map<Track>(trackCreateViewModel);
            _tracks.Add(track);
            _uow.SaveChanges();

            return Mapper.Map<TrackViewModel>(track);
        }

        public TrackViewModel Update(TrackUpdateViewModel trackViewModel)
        {
            var track = Mapper.Map<Track>(trackViewModel);

            _uow.MarkAsUnchanged(track);
            _uow.ExcludeFieldsFromUpdate(track,
                x => x.CreateDateTime);
            _uow.SaveChanges(false);

            return Detail(track.Id);
        }

        public bool Delete(TrackViewModel trackViewModel)
        {
            var site = Mapper.Map<Track>(trackViewModel);
            _uow.MarkAsDeleted(site);
            return _uow.SaveChanges() > 0;
        }

        public void Dispose()
        {
            //_uow?.Dispose();
        }
    }
}
