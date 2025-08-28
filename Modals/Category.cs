
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Category Name")]
        [MaxLength(100)]
        public string Name { get; set; }        
    }
}
