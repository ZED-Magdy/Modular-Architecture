using System.Linq.Expressions;
using ConnectionPoint.Core.Domain.Entities;
using ConnectionPoint.Core.Domain.Repositories;
using ConnectionPoint.Core.Application.Dtos;

namespace ConnectionPoint.Core.Application.Services;

public interface ICrudAppService<in TKey, TDto>
{
    Task<TDto?> GetAsync(TKey id, CancellationToken cancellationToken = default);
    Task<PaginatedResultDto<TDto>> GetListAsync(PaginationRequestDto input, CancellationToken cancellationToken = default);
    Task<TDto?> CreateAsync(TDto input, CancellationToken cancellationToken = default);
    Task<TDto?> UpdateAsync(TKey id, TDto input, CancellationToken cancellationToken = default);
    Task DeleteAsync(TKey id, CancellationToken cancellationToken = default);
}

public interface ICrudAppService<TKey, TDto, in TCreateDto,
    in TUpdateDto>
{
    Task<TDto?> GetAsync(TKey id, CancellationToken cancellationToken = default);
    Task<PaginatedResultDto<TDto>> GetListAsync(PaginationRequestDto input, CancellationToken cancellationToken = default);
    Task<TDto?> CreateAsync(TCreateDto input, CancellationToken cancellationToken = default);
    Task<TDto?> UpdateAsync(TKey id, TUpdateDto input, CancellationToken cancellationToken = default);
    Task DeleteAsync(TKey id, CancellationToken cancellationToken = default);
}