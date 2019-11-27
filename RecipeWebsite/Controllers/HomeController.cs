using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeWebsite.Models;


namespace RecipeWebsite.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeRepository repository;

        public HomeController(IRecipeRepository repo)
        {
            repository = repo;
        }

        // Default action method
        public ViewResult Index()
        {
            return View("Home");
        }
        //[HttpGet]
        //public ViewResult AddRecipe()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ViewResult AddRecipe(Recipe recipe)
        //{
        //    if (ModelState.IsValid)
        //    {            
        //        repository.SaveRecipe(recipe);              
        //        return View("Thanks", recipe);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        public ViewResult RecipeList()
        {
            return View(repository.Recipes);
            
        }
        public ViewResult ReviewRecipe()
        {
            return View();
        }
        
        public ViewResult ViewRecipe(int id)
        {
            return View(repository.Recipes.Single(r=>r.ID == id));
        }
    }
}
