﻿namespace BGB.Models
{
    using System;

    public abstract class Ad
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishedDate { get; set; }

        public AdType Type { get; set; }
    }
}
