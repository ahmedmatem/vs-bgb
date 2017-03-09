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

    [RoutePrefix("api/accommodations")]
    public class AccommodationsController : BaseController
    {
        // GET api/accommodations/id
        public HttpResponseMessage Get(int id)
        {
            AccommodationAd result = context.AccommodationAds.Find(id);

            if(result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        // GET api/accommodations/all
        [Route("All")]
        public HttpResponseMessage GetAll()
        {
            var result = context.AccommodationAds
                .OrderByDescending(x => x.PublishedDate)
                .Select(a => new AccViewModel()
                {
                    Id = a.Id,
                    Author = a.Author,
                    Title = a.Title,
                    Content = a.Content,
                    PublishedDate = a.PublishedDate,
                    Pictures = a.Pictures
                })
                .ToList<AccViewModel>();

            if (result == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { accommodations = result });
        }

        // POST api/accommodations/save
        [Route("Save")]
        public IHttpActionResult Post(AccViewModel model)
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
            if (model.BlobNames != null)
            {
                ICollection<Picture> pictures = new List<Picture>();
                foreach (string blobName in model.BlobNames)
                {
                    pictures.Add(new Picture() { Name = blobName });
                }
                accomodationAd.Pictures = pictures;
            }

            context.AccommodationAds.Add(accomodationAd);
            context.SaveChanges();            

            return Ok();
        }
    }
}
