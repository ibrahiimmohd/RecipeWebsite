using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes => context.Products;
        public IQueryable<Review> Reviews => context.Reviews;


        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.ID == 0)
            {
                context.Products.Add(recipe);
            }
            else
            {
                Recipe recipeEntry = context.Products
                    .FirstOrDefault(p => p.ID == recipe.ID);

                if (recipeEntry != null)
                {
                    recipeEntry.RecipeName = recipe.RecipeName;
                    recipeEntry.RecipeDescription = recipe.RecipeDescription;
                    recipeEntry.RecipeIngredient = recipe.RecipeIngredient;
                    recipeEntry.RecipeMethod = recipe.RecipeMethod;
                    recipeEntry.RecipePreparationTime = recipe.RecipePreparationTime;

                }
            }
            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int recipeID)
        {
            Recipe recipeEntry = context.Products
                .FirstOrDefault(p => p.ID == recipeID);

            if (recipeEntry != null)
            {
                context.Products.Remove(recipeEntry);
                context.SaveChanges();
            }

            return recipeEntry;
        }

        public void SaveReview(Review review)
        {
            if (review.ReviewId == 0)
            {
                context.Reviews.Add(review);
            }
            context.SaveChanges();
        }
    }
}
