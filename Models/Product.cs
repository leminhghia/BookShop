using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        [Key]
        public int ProId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        [Required]
        [Display(Name = "List Price")]
        [Range(1, 1000)]
        public double ListPrice { get; set; }
        [Required]
        [Display(Name = "Price for 1-50")]
        [Range(1, 1000)]
        public double Price { get; set; }
        public int CatId { get; set; }
        [ForeignKey("CatId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
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
