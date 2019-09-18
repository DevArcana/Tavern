using System.Collections.Generic;

namespace TavernApi.Models
{
  public class Function
  {
    public long Id { get; set; }
    public long Name { get; set; }
    public IEnumerable<ProjectFunction> Projects { get; set; }
  }

  public class ProjectFunction
  {
    public long ProjectId { get; set; }
    public Project Project { get; set; }
    public long FunctionId { get; set; }
    public Function Function { get; set; }
  }
}