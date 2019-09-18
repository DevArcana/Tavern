using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TavernApi.Helpers
{
  public abstract class PagedResultBase
  {
    public int CurrentPage { get; set; }
    public int PageCount { get; set; }
    public int PageSize { get; set; }
    public int RowCount { get; set; }

    public int FirstRowOnPage
    {
      get { return (CurrentPage - 1) * PageSize + 1; }
    }

    public int LastRowOnPage
    {
      get { return Math.Min(CurrentPage * PageSize, RowCount); }
    }
  }

  public class PagedResult<T> : PagedResultBase, IEnumerable<T> where T : class
  {
    public IList<T> Results { get; set; }

    public PagedResult()
    {
      Results = new List<T>();
    }

    public IEnumerator<T> GetEnumerator()
    {
      return Results.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }
  }

  public static class PagedResult
  {
    public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,
                                     int page, int pageSize) where T : class
    {
      var result = new PagedResult<T>();
      result.CurrentPage = page;
      result.PageSize = pageSize;
      result.RowCount = query.Count();


      var pageCount = (double)result.RowCount / pageSize;
      result.PageCount = (int)Math.Ceiling(pageCount);

      var skip = (page - 1) * pageSize;
      result.Results = query.Skip(skip).Take(pageSize).ToList();

      return result;
    }
  }
}
