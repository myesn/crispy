namespace Crispy.Services
{
    using Crispy.Abstractions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class CrispyQueryServicesExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> query, CryspyPageContext context)
            where T : class, new() =>
              query.Skip(context.PageIndex * context.PageSize).Take(context.PageSize);
    }
}
