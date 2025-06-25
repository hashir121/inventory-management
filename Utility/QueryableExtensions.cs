using InventoryProjectBackend.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InventoryProjectBackend.Utility
{
    public static class QueryableExtensions
    {
        public static async Task<PagedList<T>> ToPagedListAsync<T>(
            this IQueryable<T> query, int pageNumber, int pageSize
            )
        {
            var totalRecords = await query.CountAsync();
            var records = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            var totalPages = (int)Math.Ceiling(totalRecords / (double)pageSize);

            return new PagedList<T>
            {
                Records = records,
                TotalRecords = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = totalPages
            };
        }

        public static IQueryable<T> Sorting<T>(
        this IQueryable<T> query,
        string sortBy,
        string sortDirection)
        {
            var param = Expression.Parameter(typeof(T), "item");
            var sortExpression = Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Property(param, sortBy), typeof(object)), param);

            switch(sortDirection)
            {
                case "asc":
                    query = query.OrderBy<T, object>(sortExpression);
                    break;
                default:
                    query = query.OrderByDescending<T, object>(sortExpression); 
                    break;
            }

            return query;
        }
    }
}
