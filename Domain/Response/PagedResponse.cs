using System.Net;

namespace Domain.Response;

public class PagedResponse<T> : Response<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    
    public PagedResponse(int pageNumber, int pageSize, int totalRecords, T data) : base(data)
    {
        TotalPages = (int)Math.Ceiling(totalRecords / (float)pageSize);
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalRecords = totalRecords;
    }
}