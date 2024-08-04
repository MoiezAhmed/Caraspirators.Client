

namespace Caraspirators.Client.Framework.Response.Base;

public class ApiPaginatedResponse<T>
{
    public T data { get; set; }
    public int currentPage { get; set; }
    public int totalPages { get; set; }
    public int totalCount { get; set; }
    public Meta meta { get; set; }
    public int pageSize { get; set; }
    public bool hasPreviousPage { get; set; }
    public bool hasNextPage { get; set; }
    public List<object> messages { get; set; }
    public bool succeeded { get; set; }
}

public class Meta
{
    public int Count { get; set; }
}
