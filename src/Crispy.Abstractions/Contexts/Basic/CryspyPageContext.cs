namespace Crispy.Abstractions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class CryspyPageContext
    {
        [Range(1, 100, ErrorMessage = "页大小的值应为 1 - 100")]
        public int PageSize { get; set; } = 10;

        [Range(0, double.MaxValue, ErrorMessage = "页索引必须大于等于 0")]
        public int PageIndex { get; set; } = 0;
    }
}
