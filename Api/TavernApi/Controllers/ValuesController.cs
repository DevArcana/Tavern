using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TavernApi.Databases;

namespace TavernApi.Controllers
{
  [Route("api/values")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    //private readonly TestContext _context;

    //public ValuesController(TestContext context)
    //{
    //  _context = context;
    //}

    // GET api/values
    [HttpGet]
    [Route("lol")]
    public ActionResult<IEnumerable<string>> Get()
    {
      return new string[] { "value1", "value2" };
    }

    // GET api/values/5
    //[HttpGet("{id}")]
    //public ActionResult<TestDTO> Get(long id)
    //{
    //  var test = _context.Tests.Find(id);
    //  if (test != null)
    //  {
    //    return new TestDTO(test);
    //  }
    //  else
    //    return null;
    //}

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
