using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavernApi.Models.Identity;

namespace TavernApi.Models
{
  public class Project
  {
    public long Id { get; set; }
    public string Title { get; set; }
    public virtual Category Category { get; set; }
    public virtual IEnumerable<ProjectRole> Roles { get; set; }
    public string Description { get; set; }
    //public virtual IEnumerable<Comment> Comments { get; set; }
    public DateTime CreationTimeStamp { get; set; }
    public virtual User Creator { get; set; }
  }


  public class ProjectDTO
  {
    public long Id { get; set; }
    public string Title { get; set; }
    public virtual CategoryDTO Category { get; set; }
    public virtual IEnumerable<ProjectRoleDTO> Roles { get; set; }
    public string Description { get; set; }
    //public virtual IEnumerable<Comment> Comments { get; set; }
    public DateTime CreationTimeStamp { get; set; }
    public virtual UserDTO Creator { get; set; }

    public ProjectDTO(Project project)
    {
      Id = project.Id;
      Title = project.Title;
      Category = new CategoryDTO(project.Category);
      Roles = project.Roles.Select(role => new ProjectRoleDTO(role));
      Description = project.Description;
      CreationTimeStamp = project.CreationTimeStamp;
      Creator = new UserDTO(project.Creator);
    }
  }
}
