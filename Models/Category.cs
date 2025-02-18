using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Category
    {
        [Key]
        public int CatId { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name")]
        public string Name { get; set; }

        public string? Description { get; set; }

        [DisplayName("Created At")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Created By")]
        [MaxLength(50)]
        public string? CreatedBy { get; set; }

        [DisplayName("Updated At")]
        public DateTime? UpdatedAt { get; set; }

        [DisplayName("Updated By")]
        [MaxLength(50)]
        public string? UpdatedBy { get; set; }
    }
}
