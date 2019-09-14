using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavernApi.Models
{
  public class Category
  {
    public long Id { get; set; }
    public string Name { get; set; }
  }

  public class CategoryDTO
  {
    public long Id { get; set; }
    public string Name { get; set; }

    public CategoryDTO() { }
    public CategoryDTO(Category category)
    {
      Id = category.Id;
      Name = category.Name;
    }
  }
}


