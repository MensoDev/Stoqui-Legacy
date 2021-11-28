namespace Stoqui.Kernel.Domain.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> Pagination<T>(this IQueryable<T> queryable, int page, ushort pageSize)
    {
        return queryable
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
    }

    public static int GetTotalPage<T>(this IQueryable<T> queryable, ushort pageSize)
    {
        double totalItems = queryable.Count();
        return (int)Math.Ceiling( totalItems / pageSize);

    }
}