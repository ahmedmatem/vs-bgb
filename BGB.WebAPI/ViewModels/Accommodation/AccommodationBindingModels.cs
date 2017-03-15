namespace BGB.WebAPI.ViewModels
{
    using System.Collections.Generic;

    using Models;

    public class AccommodationBindingModel : AdBindingModel
    {
        public AccommodationBindingModel()
        {
            this.ImageNames = new List<string>();
            this.ThumbnailNames = new List<string>();
        }

        public ICollection<string> ImageNames { get; set; }

        public ICollection<string> ThumbnailNames { get; set; }
    }

    public class SaveBindingModel : AdBindingModel
    {
        public ICollection<string> ImageNames { get; set; }

        public ICollection<string> ThumbnailNames { get; set; }
    }
}