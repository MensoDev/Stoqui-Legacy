namespace Stoqui.Kernel.Domain.Objects;

public class PagingResult<TEntity>
{

    public PagingResult(int totalPages, int pageNumber, ushort pageSize, int totalItems, IEnumerable<TEntity> values)
    {
        TotalPages = totalPages;
        PageNumber = pageNumber;
        PageSize = pageSize;
        Values = values;
        TotalItems = totalItems;
    }

    public int TotalPages { get; private set; }
    public int TotalItems { get; private set; }
    public int PageNumber { get; private set;}
    public ushort PageSize { get; private set;}

    public IEnumerable<TEntity> Values { get; private set; }
}

