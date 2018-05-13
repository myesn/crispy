namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CrispyPageResponse<T> where T : class, new()
    {
        public IEnumerable<T> Data { get; set; } = new List<T>();
        public int Total { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
