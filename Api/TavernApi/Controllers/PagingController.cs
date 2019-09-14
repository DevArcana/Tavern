﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TavernApi.Models;

namespace TavernApi.Controllers
{
  public static class PagingController
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
