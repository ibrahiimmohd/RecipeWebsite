using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace RecipeWebsite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IRecipeRepository repository;

        public AdminController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index() => View(repository.Recipes);

        public ViewResult Edit(int recipeId) =>
            View(repository.Recipes
                .FirstOrDefault(p => p.ID == recipeId));

        [HttpPost]
        public IActionResult Edit(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.RecipeName} has been saved!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(recipe);
            }
        }

        public ViewResult Create() => View("Edit", new Recipe());

        [HttpPost]
        public IActionResult Delete(int recipeId)
        {
            Recipe deletedProduct = repository.DeleteProduct(recipeId);

            if (deletedProduct != null)
            {
                TempData["message"] = $"{deletedProduct.RecipeName} was deleted!";
            }

            return RedirectToAction("Index");
        }

    }
}
