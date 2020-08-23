using System;
using System.Web.Http;
using System.Web.Http.Description;
using EfConcurrency.Common;
using EfConcurrency.ServicesLayer.IServices;
using EfConcurrency.ServicesLayer.ViewModels.Album;
using EfConcurrency.ServicesLayer.ViewModels.PublicViewModel;
using EfConcurrency.Web.FilterAttribute;

namespace EfConcurrency.Web.Api
{
    [RoutePrefix(ConstantSettings.ApiVersion)]
    public class AlbumController : ApiController
    {
        private readonly IAlbumService _albumService;
        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        /// <summary>
        /// Detail of an album
        /// </summary>
        /// <param name="id">Album id</param>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(ResponseObject<AlbumViewModel>))]
        public IHttpActionResult Detail(Guid id)
        {
            var album = _albumService.Detail(id);
            if (album == null)
                return Ok(ResponseObject<string>.NotFound());

            var response = new ResponseObject<AlbumViewModel>
            {
                StatusEnum = MessageType.Success,
                Result = album
            };
            return Ok(response);
        }

        /// <summary>
        /// Create a new album
        /// </summary>
        /// <param name="albumCreateViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ModelValidator]
        [Route("Album/Create")]
        [ResponseType(typeof(ResponseObject<AlbumViewModel>))]
        public IHttpActionResult Create(AlbumCreateViewModel albumCreateViewModel)
        {
            var response = new ResponseObject<AlbumViewModel>
            {
                StatusEnum = MessageType.Error,
            };

            response.StatusEnum = MessageType.Success;
            response.Result = _albumService.Create(albumCreateViewModel);
            return Ok(response);
        }
    }
}
