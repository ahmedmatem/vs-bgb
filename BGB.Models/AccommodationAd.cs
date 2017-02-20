namespace BGB.Models
{
    using System.Collections.Generic;


    public class AccommodationAd : Ad
    {
        public AccommodationAd()
        {
            this.Pictures = new HashSet<Picture>();
        }

        // Navigation properties

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
