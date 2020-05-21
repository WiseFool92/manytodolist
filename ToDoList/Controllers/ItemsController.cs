using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    [HttpGet("/categories/{categoryId}/items/new")] // The path now includes the ID of the Category we're adding a new Item to. Because it's in curly braces, we can grab this in our route's parameter to locate the Category object and pass it into the corresponding view
    public ActionResult New(int categoryId)
    {
      Category category = Category.Find(categoryId);
      return View(category);
    }

    [HttpGet("/categories/{categoryId}/items/{itemId}")] // The path now includes Category information, which ensures our routes are now RESTfully named.
    public ActionResult Show(int categoryId, int itemId) // Because the path includes both Item and Category IDs, we can locate the correct parent and child objects and pass them to our view in a Dictionary.
    {
      Item item = Item.Find(itemId);
      Category category = Category.Find(categoryId);
      Dictionary<string, object> model = new Dictionary<string, object>();
      model.Add("item", item);
      model.Add("category", category);
      return View(model);
    }

    [HttpPost("/items/delete")]
    public ActionResult DeleteAll()
    {
      Item.ClearAll();
      return View();
    }
  }
}