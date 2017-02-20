namespace BGB.WebAPI.Controllers
{
    using Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class BaseController : ApiController
    {
        protected ApplicationDbContext context;

        public BaseController()
        {
            this.context = ApplicationDbContext.Create();
        }
    }
}
