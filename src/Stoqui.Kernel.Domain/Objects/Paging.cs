using System.Linq.Expressions;

namespace Stoqui.Kernel.Domain.Objects;

public class Paging<TEntity>
{

    public Paging(
        ushort pageNumber = 1, 
        ushort pageSize = 10, 
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "")
    {
        
        PageNumber = pageNumber;
        PageSize = pageSize;

        Filter = filter;
        OrderBy = orderBy;
        IncludeProperties = string.Empty;

        ChangeToOneWhenZeroInPageNumberAndPageSize();
    }

    public ushort PageNumber { get; private set; }
    public ushort PageSize { get; private set; }


    public Expression<Func<TEntity, bool>>?  Filter { get; private set; }
    public Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? OrderBy { get; private set; }

    public string IncludeProperties { get; private set; }

    private void ChangeToOneWhenZeroInPageNumberAndPageSize()
    {
        if (PageNumber == 0) PageNumber = 1;
        if (PageSize == 0) PageSize = 1;
    }

}

