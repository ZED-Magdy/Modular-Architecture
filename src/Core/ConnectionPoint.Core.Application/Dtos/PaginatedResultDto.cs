namespace ConnectionPoint.Core.Application.Dtos;

public class PaginatedResultDto<TDto>
{
    public int Page { get; private set; }
    public int PerPage { get; private set; }
    public int Total { get; private set; }
    public int TotalPages { get; private set; }
    public List<TDto?> Data { get; private set; }
    
    public PaginatedResultDto(int page, int perPage, int total, int totalPages, List<TDto?> data)
    {
        Page = page;
        PerPage = perPage;
        Total = total;
        TotalPages = totalPages;
        Data = data;
    }
}