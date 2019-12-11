using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models.ViewModels
{
    public class RecipeReviewsViewModel
    {
        public Recipe Recipe;
        public IEnumerable<Review> Reviews = new List<Review>();
    }
}
