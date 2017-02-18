namespace BGB.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public int AccommodationAdId { get; set; }

        public virtual AccommodationAd AccommodationAd { get; set; }
    }
}
