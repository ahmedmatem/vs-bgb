namespace BGB.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int AccommodationAdId { get; set; }

        // Navigation properties
        public virtual AccommodationAd AccommodationAd { get; set; }
    }
}
