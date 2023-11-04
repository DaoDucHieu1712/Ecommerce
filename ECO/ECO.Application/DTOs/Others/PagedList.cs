using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECO.Application.DTOs.Others
{
    public class PagedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PagedList(List<T> items, int count, int pageIndex, int paeSize)
        {
            pageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)paeSize);
            this.AddRange(items);
        }

        public static async Task<PagedList<T>> CreateAsync(List<T> source, int pageIndex, int pageSize)
        {
            var count = source.Count;
            var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageIndex, pageSize);
        }
    }

}

