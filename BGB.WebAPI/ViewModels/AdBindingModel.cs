namespace BGB.WebAPI.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class AdBindingModel
    {
        public int Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        public string Content { get; set; }
    }
}