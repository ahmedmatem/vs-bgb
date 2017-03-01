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
                .Select(a => a)
                .ToList<AccommodationAd>();

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
                PublishedDate = DateTime.Now
            };

            context.AccommodationAds.Add(accomodationAd);
            context.SaveChanges();            

            return Ok();
        }
    }
}
