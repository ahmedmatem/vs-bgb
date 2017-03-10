namespace BGB.WebAPI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    using Models;

    public class AccViewModel : AdViewModel
    {
        public ICollection<PictureViewModel> Blobs { get; set; }

        public ICollection<string> BlobNames { get; set; }
    }
}