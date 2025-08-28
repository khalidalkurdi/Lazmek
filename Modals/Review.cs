using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyProject.Models;

namespace Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey (nameof(user))]
        public string UserId { get; set; }
        public ApplicationUser user { get; set; }
        [Required]
        [Range(0, 5)]
        public double Rate { get; set; }
        [ForeignKey(nameof(product))]
        public int productId {  get; set; }
        public Product product { get; set; }

    }
}
