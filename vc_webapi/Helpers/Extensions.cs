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
        public static async Task<int> AddRangeIfNotExistsAsync<T, TKey>(this DbSet<T> dbSet, ICollection<T> entities, Func<T, TKey> predicate) where T : class
        {
            //Would be lovely if this actually worked ;(
            var entitiesExist = await dbSet.Where(c => entities.Select(predicate).Contains(predicate(c))).ToDictionaryAsync(e => predicate(e), e => e);
            var toAdd = entities.Where(c => !entitiesExist.TryGetValue(predicate(c), out T _)).ToList();

            dbSet.AddRange(toAdd);

            return toAdd.Count();
        }
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
