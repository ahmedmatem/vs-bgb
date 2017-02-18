namespace BGB.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    public class AccommodationAd : Ad
    {
        public AccommodationAd()
        {
            this.Pictures = new HashSet<Picture>();
        }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
