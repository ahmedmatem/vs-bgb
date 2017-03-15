namespace BGB.Models
{
    public class Thumbnail : Picture
    {
        public int AccommodationId { get; set; }

        // Navigation properties
        public virtual AccommodationAd Accommodations { get; set; }
    }
}
