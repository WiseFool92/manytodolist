// using System.Collections.Generic;
// using System;
// using Microsoft.AspNetCore.Mvc;
// using ToDoList.Models;

// namespace ToDoList.Controllers
// {
//   public class CategoriesController : Controller
//   {
//     [HttpGet("/categories")]
//     public ActionResult Index()
//     {
//       List<Category> allCategories = Category.GetAll();
//       return View(allCategories);
//     }

//     [HttpGet("/categories/new")]
//     public ActionResult New()
//     {
//       return View();
    
//     }

//     [HttpPost("/categories")] // Creates categories
//     public ActionResult Create(string categoryName)
//     {
//       Category newCategory = new Category(categoryName);
//       return RedirectToAction("Index");
//     }

//     [HttpGet("/categories/{id}")]
//     public ActionResult Show (int id)
//     {
//       Dictionary<string, object> model = new Dictionary<string, object>(); // Create a new Dictionary called model because a Dictionary can hold multiple key-value pairs.
//       Category selectedCategory = Category.Find(id);
//       List<Item> categoryItems = selectedCategory.Items; // Add both the Category and its associated Items to this Dictionary.
//       model.Add("category", selectedCategory); // These will be stored with the keys "category" and "items".
//       model.Add("items", categoryItems);
//       return View(model); // The Dictionary, which is named model, will be passed into View().
//     }

//     // This one creates new Items within a given Category, not new Categories:
//     [HttpPost("/categories/{categoryId}/items")]
//     public ActionResult Create(int categoryId, string itemDescription) // The method now takes two arguments: the categoryId we passed into a hidden form field and an itemDescription that contains the user's form input.
//     {
//       Dictionary<string, object> model = new Dictionary<string, object>();
//       Category foundCategory = Category.Find(categoryId); // Using the categoryId provided as an argument, we locate the Category object our new Item should belong to and call it foundCategory.
//       Item newItem = new Item(itemDescription); // We then create a new Item object with the user's form input.
//       newItem.Save();
//       foundCategory.AddItem(newItem); // We add the newItem to the foundCategory with our existing AddItem() method.
//       List<Item> categoryItems = foundCategory.Items; // We retrieve all other Items that correspond to this category and add it to our model. We do this because the view we'll render at the end of this route requires this information.
//       model.Add("items", categoryItems);
//       model.Add("category", foundCategory); // We also add the foundCategory to our model.
//       return View("Show", model); // Finally, we pass in our model data to View(), instructing it to render the Category detail page, which is the Show.cshtml view.
//     }
//   }
// }