using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public int RecipeId { get; set; }
        public string Description { get; set; } //String
        public int Rating { get; set; }
    }
}
