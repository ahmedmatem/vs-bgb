namespace BGB.Models
{
    using System;
    using System.Collections.Generic;


    public class AccommodationAd : Ad
    {
        public AccommodationAd()
        {
            this.AdImages = new HashSet<Picture>();
            this.Thumbnails = new HashSet<Picture>();
        }

        // Navigation properties

        public virtual ICollection<Picture> AdImages { get; set; }

        public virtual ICollection<Picture> Thumbnails { get; set; }
    }
}
