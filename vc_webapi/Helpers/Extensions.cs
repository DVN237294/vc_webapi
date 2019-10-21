using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vc_webapi.Data;
using vc_webapi.Model;

namespace vc_webapi.Helpers
{
    public static class Extensions
    {
        public static IQueryable<T> If<T>(this IQueryable<T> source, bool condition, Func<IQueryable<T>, IQueryable<T>> transform)
        {
            //Code gracefully stolen from: https://entityframeworkcore.com/knowledge-base/53474431/ef-core-linq-and-conditional-include-and-theninclude-problem
            return condition ? transform(source) : source;
        }
        public static IQueryable<T> If<T, P>(this IIncludableQueryable<T, P> source, bool condition, Func<IIncludableQueryable<T, P>, IQueryable<T>> transform) where T : class
        {
            return condition ? transform(source) : source;
        }
        public static IQueryable<T> If<T, P>(this IIncludableQueryable<T, IEnumerable<P>> source, bool condition, Func<IIncludableQueryable<T, IEnumerable<P>>, IQueryable<T>> transform) where T : class
        {
            return condition ? transform(source) : source;
        }
        public static async Task<User> User(this ControllerBase controller, Vc_webapiContext db)
        {
            if (controller.User.Identity.IsAuthenticated)
            {
                string userName = controller.User.Claims.SingleOrDefault(claim => claim.Type == "UserName")?.Value;
                if (!string.IsNullOrEmpty(userName))
                    return await db.Users.SingleOrDefaultAsync(user => user.UserName == userName);
            }
            return null;
        }
    }
}
