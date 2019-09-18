using System.Collections.Generic;

namespace TavernApi.Models
{
  public class Category
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<Project> Projects { get; set; }
  }
}