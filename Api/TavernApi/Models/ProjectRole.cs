namespace TavernApi.Models
{
  public class ProjectRole
  {
    public long Id { get; set; }
    public string Name { get; set; }
  }

  public class ProjectRoleDTO
  {
    public long Id { get; set; }
    public string Name { get; set; }

    public ProjectRoleDTO() { }
    public ProjectRoleDTO(ProjectRole project)
    {
      Id = project.Id;
      Name = project.Name;
    }
  }
}
