using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }
        IQueryable<Review> Reviews { get; }


        void SaveRecipe(Recipe recipe);

        void SaveReview(Review review);


        Recipe DeleteRecipe(int recipeID);
    }
}
