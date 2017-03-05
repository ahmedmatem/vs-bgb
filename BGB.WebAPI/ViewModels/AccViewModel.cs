namespace BGB.WebAPI.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class AccViewModel : AdViewModel
    {
        public ICollection<string> BlobNames { get; set; }
    }
}