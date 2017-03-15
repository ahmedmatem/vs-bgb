namespace BGB.Models
{
    using System;
    using System.Collections.Generic;


    public class AccommodationAd : Ad
    {
        public AccommodationAd()
        {
            this.AdImages = new HashSet<AdImage>();
            this.Thumbnails = new HashSet<Thumbnail>();
        }

        // Navigation properties

        public virtual ICollection<AdImage> AdImages { get; set; }

        public virtual ICollection<Thumbnail> Thumbnails { get; set; }
    }
}
