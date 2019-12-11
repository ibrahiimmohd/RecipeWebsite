using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RecipeWebsite.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Recipe
                    {
                        RecipeName = "Steve's Roasted Chicken Soft Tacos",
                        RecipeDescription = "Rotisserie chicken soft tacos made with homemade flour tortillas and pico de gallo.",
                        RecipeIngredient = "1 teaspoon vegetable oil. 1 rotisserie chicken. meat removed and chopped. 1 tablespoon chili powder. 1 teaspoon cayenne pepper. salt and ground black pepper to taste. 12 flour tortillas. 2 cups pico de gallo salsa. 1/2 cup shredded Mexican cheese blend",
                        RecipeMethod = "Heat vegetable oil in a skillet over medium heat; cook and stir chicken, chili powder, cayenne pepper, salt, and black pepper together in the hot oil until chicken is heated through, about 10 minutes. Spoon chicken mixture onto each tortilla and top with pico de gallo and Mexican cheese blend.",
                        RecipePreparationTime = 25
                    },
                    new Recipe
                    {
                        RecipeName = "Shrimp De Jonghe",
                        RecipeDescription = "Shrimp de jonghe was invented at the turn of the 20th century by the De Jonghe brothers, Belgian immigrants and owners of DeJonghe's Hotel and Restaurant in Chicago. This garlicky, herbed casserole is one of the earliest Windy City specialties. This dish can be served as an appetizer or main course.",
                        RecipeIngredient = "3 pounds cooked shrimp. 2/3 cup bread crumbs. 1/2 cup dry sherry. 1/4 pound butter. 1 large clove garlic, minced. 1 teaspoon salt1 pinch tarragon. 1 pinch marjoram. 1 teaspoon parsley, or to taste",
                        RecipeMethod = "Preheat the oven to 400 degrees F (200 degrees C). Place shrimp in a baking dish. Combine bread crumbs, sherry, butter, garlic, salt, tarragon, and marjoram in a bowl. Sprinkle mixture on top of shrimp in the baking dish. Sprinkle parsley on top. Bake in the preheated oven until golden brown, about 25 minutes.",
                        RecipePreparationTime = 40
                    }
                );
                if (!context.Reviews.Any())
                {
                    new Review
                    {
                        RecipeId = 1,
                        Rating = 5,
                        Description = "Great"
                    };
                }
                context.SaveChanges();
            }
        }
    }
}

