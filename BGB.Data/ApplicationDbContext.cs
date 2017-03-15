namespace BGB.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using BGB.Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Thumbnail> Thumbnails { get; set; }

        public IDbSet<AdImage> AdImages { get; set; }

        public IDbSet<AccommodationAd> AccommodationAds { get; set; }
    }
}
