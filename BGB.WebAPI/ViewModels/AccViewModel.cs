namespace BGB.WebAPI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Models;

    public class AccViewModel : AdViewModel
    {
        // use this property for downloading images
        public ICollection<PictureViewModel> Blobs { get; set; }

        // use this property for upload images
        public ICollection<string> BlobNames { get; set; }
    }
}