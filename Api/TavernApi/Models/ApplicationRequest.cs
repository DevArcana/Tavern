using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavernApi.Models.Identity;

namespace TavernApi.Models
{
  public class ApplicationRequest
  {
    public long Id { get; set; }
    public long ProjectId { get; set; }
    public User Applicant { get; set; }
    public Function Function { get; set; }
    public bool? Approved { get; set; } = null;
  }
}
