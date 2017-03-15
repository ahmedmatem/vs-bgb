namespace BGB.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using Data.Common.Repository;
    using Models;

    using ViewModels;
    using System.Data.Entity;
    using Data;
    using Infrastructure.Util;

    [RoutePrefix("api/accommodation")]
    public class AccommodationController : BaseController
    {
        // GET api/accommodation/id
        public HttpResponseMessage Get(int id)
        {
            AccommodationAd result = context.AccommodationAds.Find(id);
            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            AccommodationBindingModel model = new AccommodationBindingModel();
            model.Id = result.Id;
            model.Author = result.Author;
            model.Title = result.Title;
            model.Content = result.Content;
            model.PublishedDate = result.PublishedDate;
            model.ImageNames = Accommodation.GetImageNames(result.AdImages);
            model.ThumbnailNames = Accommodation.GetThumbnailNames(result.Thumbnails);

            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        // GET api/accommodation/all
        [Route("All")]
        public HttpResponseMessage GetAll()
        {
            var accommodationAds = context.AccommodationAds
                .OrderByDescending(x => x.PublishedDate)
                .Select(a => a)
                .ToList<AccommodationAd>();
            if (accommodationAds == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            ICollection<AccommodationBindingModel> result = new List<AccommodationBindingModel>();
            AccommodationBindingModel model = null;
            foreach (AccommodationAd accommodationAd in accommodationAds)
            {
                model = new AccommodationBindingModel();
                model.Id = accommodationAd.Id;
                model.Author = accommodationAd.Author;
                model.Title = accommodationAd.Title;
                model.Content = accommodationAd.Content;
                model.PublishedDate = accommodationAd.PublishedDate;
                model.ImageNames = Accommodation.GetImageNames(accommodationAd.AdImages);
                model.ThumbnailNames = Accommodation.GetThumbnailNames(accommodationAd.Thumbnails);

                result.Add(model);
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { Accommodations = result });
        }

        // POST api/accommodation/save
        [Route("Save")]
        public IHttpActionResult Post(SaveBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accomodationAd = new AccommodationAd()
            {
                Title = model.Title,
                Author = model.Author,
                Content = model.Content,
                PublishedDate = DateTime.Now,
            };

            if (model.ImageNames != null)
            {
                ICollection<AdImage> images = new List<AdImage>();
                foreach (string imageName in model.ImageNames)
                {
                    images.Add(new AdImage() { Name = imageName });
                }
                accomodationAd.AdImages = images;
            }

            if (model.ThumbnailNames != null)
            {
                ICollection<Thumbnail> thumbnails = new List<Thumbnail>();
                foreach (string thumbnailName in model.ThumbnailNames)
                {
                    thumbnails.Add(new Thumbnail() { Name = thumbnailName });
                }
                accomodationAd.Thumbnails = thumbnails;
            }

            context.AccommodationAds.Add(accomodationAd);
            context.SaveChanges();

            return Ok();
        }
    }
}
