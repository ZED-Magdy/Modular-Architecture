namespace ConnectionPoint.Core.Application.Dtos;

public class PaginationRequestDto
{
    public int PerPage { get; set; } = 10;
    public int Page { get; set; } = 1;
    public string? SortBy { get; set; } = "Id";
    public string? SortDirection { get; set; } = "asc";
    public string? Search { get; set; }
}