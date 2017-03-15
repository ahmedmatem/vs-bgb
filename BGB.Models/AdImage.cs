namespace BGB.Models
{
    public class AdImage : Ad
    {
        public int AccommodationId { get; set; }

        // Navigation properties
        public virtual Ad Accommodations { get; set; }
    }
}
