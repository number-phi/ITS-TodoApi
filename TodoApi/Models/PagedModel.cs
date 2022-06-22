using System;
using System.Collections.Generic;

namespace TodoApi.Models
{
    public class PagedModel<TModel>
    {
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IList<TModel> Items { get; set; }

        public PagedModel(IEnumerable<TModel> items, int page, int limit, int tot)
        {
            Items = items != null ? new List<TModel>(items) : new List<TModel>();
            CurrentPage = page;
            TotalItems = tot;
            TotalPages = (int)Math.Ceiling(TotalItems / (double)limit);
        }
    }
}
