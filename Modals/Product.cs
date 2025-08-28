
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Models;


namespace MyProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public int Quantity { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateOnly CreateAt { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        public string? Brand { get; set; }               
        [Required]
        [DisplayName("List Price ")]
        [Range(1,1000)]
        public double ListPrice { get; set; }
        [Required]
        [DisplayName("Price for 1-50")]
        [Range(1,1000)]
        public double Price { get; set; }
        [Required]
        [DisplayName("Price for 50+")]
        [Range(1,1000)]
        public double Price50 { get; set; }
        [Required]
        [DisplayName("Price for 100+")]
        [Range(1,1000)]
        public double Price100 { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        [DisplayName("Images")]
        public List<ProductImage> ProductImages{ get; set; }

        [NotMapped]
        [Range(0.0, 5.0)]
        public double Rating => Reviews == null || !Reviews.Any() ? 0.0 : Reviews.Average(r => r.Rate) ;
        [ValidateNever]
        public List<Review> Reviews { get; set; }



    }
}
