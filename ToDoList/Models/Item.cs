using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace ToDoList.Models
{
  public class Item
  {
    public Item()
    {
      this.Categories = new HashSet<CategoryItem>();
    }
    public int ItemId { get; set; }
    public string Description { get; set; }

    public ICollection<CategoryItem> Categories { get; }

    // Code below may be superfluous extra
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }
  }

  public class CategoryItem
  {
    public int CategoryItemId { get; set; }
    public int ItemId { get; set; }
    public int CategoryId { get; set; }
    public Item Item { get; set; }
    public Category Category { get; set; }
  }
}