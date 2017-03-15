namespace BGB.WebAPI.Controllers
{
    using Data;
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
