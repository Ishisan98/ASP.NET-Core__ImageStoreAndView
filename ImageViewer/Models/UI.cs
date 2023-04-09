using System.ComponentModel.DataAnnotations.Schema;

namespace ImageViewer.Models
{
    public class UI
    {
        public int Id { get; set; }

        public string ImageName { get; set; }

        public string UrlImage { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
