using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using EfConcurrency.DataLayer.Context;
using EfConcurrency.DataLayer.Entities;
using EfConcurrency.ServicesLayer.IServices;
using EfConcurrency.ServicesLayer.ViewModels.Album;

namespace EfConcurrency.ServicesLayer.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IUnitOfWork _uow;
        private readonly IDbSet<Album> _albums;

        public AlbumService(IUnitOfWork uow)
        {
            _uow = uow;
            _albums = _uow.Set<Album>();
        }

        public AlbumViewModel Detail(Guid id)
        {
            return _albums
                .Where(current => current.Id == id)
                .AsNoTracking()
                .AsEnumerable()
                .Select(Mapper.Map<AlbumViewModel>)
                .FirstOrDefault();
        }

        public List<AlbumViewModel> List()
        {
            return _albums
                .AsNoTracking()
                .AsEnumerable()
                .Select(Mapper.Map<AlbumViewModel>)
                .ToList();
        }

        public AlbumViewModel Create(AlbumCreateViewModel albumCreateViewModel)
        {
            var album = Mapper.Map<Album>(albumCreateViewModel);
            _albums.Add(album);
            _uow.SaveChanges();

            return Detail(album.Id);
        }

        public AlbumViewModel Update(AlbumUpdateViewModel albumViewModel)
        {
            var album = Mapper.Map<Album>(albumViewModel);

            _uow.MarkAsUnchanged(album);
            _uow.ExcludeFieldsFromUpdate(album,
                x => x.CreateDateTime);
            _uow.SaveChanges(false);

            return Detail(album.Id);
        }

        public bool Delete(AlbumViewModel albumViewModel)
        {
            var site = Mapper.Map<Album>(albumViewModel);
            _uow.MarkAsDeleted(site);
            return _uow.SaveChanges() > 0;
        }

        #region ### Safe methods ###
        public AlbumViewModel DetailSafely(Guid id)
        {
            return _uow.ExecuteSafely(() => Detail(id));
        }

        public List<AlbumViewModel> ListSafely()
        {
            return _uow.ExecuteSafely(List);
        }

        public AlbumViewModel AddSafely(AlbumCreateViewModel albumCreateViewModel)
        {
            return _uow.ExecuteSafely(() => Create(albumCreateViewModel));
        }

        public AlbumViewModel UpdateSafely(AlbumUpdateViewModel albumViewModel)
        {
            return _uow.ExecuteSafely(() => Update(albumViewModel));
        }

        public bool DeleteSafely(AlbumViewModel albumViewModel)
        {
            return _uow.ExecuteSafely(() => Delete(albumViewModel));
        }
        #endregion

        public void Dispose()
        {
            //_uow?.Dispose();
        }
    }
}
