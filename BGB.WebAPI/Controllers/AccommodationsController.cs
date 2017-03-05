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
            var accAds = context.AccommodationAds
                .OrderByDescending(x => x.PublishedDate)
                .Select(a => a)
                .ToList<AccommodationAd>();

            ICollection<AccViewModel> resultAsAccViewModel = new List<AccViewModel>();
            foreach (AccommodationAd accAd in accAds)
            {
                resultAsAccViewModel.Add(new AccViewModel()
                {
                    Id = accAd.Id,
                    Author = accAd.Author,
                    Title = accAd.Title,
                    Content = accAd.Content,
                    BlobNames = ExtractBlobNamesFromPictures(accAd.Pictures)
                });
            }

            if (accAds == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { accommodations = resultAsAccViewModel });
        }

        private ICollection<string> ExtractBlobNamesFromPictures(ICollection<Picture> pictures)
        {
            if(pictures == null)
            {
                return null;
            }

            ICollection<string> blobNames = new List<string>();

            foreach (Picture picture in pictures)
            {
                blobNames.Add(picture.Name);
            }

            return blobNames;
        }

        // POST api/accommodations/save
        [Route("Save")]
        public IHttpActionResult Post(AccViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ICollection<Picture> pictures = new List<Picture>();
            foreach (string blobName in model.BlobNames)
            {
                pictures.Add(new Picture() { Name = blobName });
            }

            var accomodationAd = new AccommodationAd()
            {
                Title = model.Title,
                Author = model.Author,
                Content = model.Content,
                PublishedDate = DateTime.Now,
                Pictures = pictures,
            };

            context.AccommodationAds.Add(accomodationAd);
            context.SaveChanges();            

            return Ok();
        }
    }
}
