namespace BGB.Models
{
    public class AdImage : Picture
    {
        public int AccommodationId { get; set; }

        // Navigation properties
        public virtual AccommodationAd Accommodation { get; set; }
    }
}
