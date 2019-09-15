using System.Collections;
using System.Collections.Generic;

namespace TavernApi.Models
{
  public class Function
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public virtual IEnumerable<ProjectFunction> Projects { get; set; }
  }

  public class FunctionDTO
  {
    public long Id { get; set; }
    public string Name { get; set; }

    public FunctionDTO() { }
    public FunctionDTO(Function project)
    {
      Id = project.Id;
      Name = project.Name;
    }
  }

  public class ProjectFunction
  {
    public long ProjectId { get; set; }
    public virtual Project Project { get; set; }

    public long FunctionId { get; set; }
    public virtual Function Function { get; set; }
  }
}
