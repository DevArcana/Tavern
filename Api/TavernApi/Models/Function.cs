namespace TavernApi.Models
{
  public class Function
  {
    public long Id { get; set; }
    public string Name { get; set; }
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
}
