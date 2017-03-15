namespace BGB.Infrastructure.Util
{
    using System.Collections.Generic;

    using Models;

    public class Accommodation
    {
        public static ICollection<string> GetImageNames(ICollection<AdImage> images)
        {
            ICollection<string> result = new List<string>();
            foreach (var image in images)
            {
                result.Add(image.Name);
            }
            return result;
        }

        public static ICollection<string> GetThumbnailNames(ICollection<Thumbnail> thumbnails)
        {
            ICollection<string> result = new List<string>();
            foreach (var thumbnail in thumbnails)
            {
                result.Add(thumbnail.Name);
            }
            return result;
        }
    }
}
