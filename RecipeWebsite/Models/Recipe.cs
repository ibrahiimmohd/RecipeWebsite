using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecipeWebsite.Models
{  
    public class Recipe
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter recipe's name")]
        public String RecipeName { get; set; }
        [Required(ErrorMessage = "Please enter recipe's ingredient")]
        public string RecipeIngredient { get; set; }
        [Required(ErrorMessage = "Please enter recipe's method")]
        public string RecipeMethod { get; set; }
        [Required(ErrorMessage = "Please enter recipe's decription")]
        public string RecipeDescription { get; set; }
        [Required(ErrorMessage = "Please enter recipe's preparation time")]
        public int? RecipePreparationTime { get; set; }
    }
}
