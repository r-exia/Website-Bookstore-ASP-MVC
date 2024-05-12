

using System.ComponentModel.DataAnnotations;

namespace detai_website_asp.Models
{
    public class TinTuc
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string TieuDe { get; set; }
        public DateTime ThoiGian { get; set; } = DateTime.Now;
        [Required]
        public string? NoiDung { get; set; }
        public string? ImageUrl { get; set; }

    }
}
