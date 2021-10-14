using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessLogicLayer.Utilities
{
    public class Pager
    {
        private const int _defaultPageSize = 10;
        private int _page;
        private int _pageSize;
        private int _totalRecords;

        public int Page
        {
            get { return Math.Max(Math.Min(_page, PageCount), 1); }
            set { _page = Math.Max(Math.Min(value, PageCount), 1); }
        }
        public int? TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value.HasValue ? value.Value : 0; }
        }
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > 0 ? value : _defaultPageSize; }
        }
        public int PageCount => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public int Skip => Math.Max(0, Page - 1) * PageSize;

        public Pager(int? totalRecords, int? page, int? pageSize)
        {
            TotalRecords = totalRecords;

            PageSize = !pageSize.HasValue ? TotalRecords.Value : pageSize.Value;

            Page = !page.HasValue ? 1 : page.Value;
        }

    }
}
