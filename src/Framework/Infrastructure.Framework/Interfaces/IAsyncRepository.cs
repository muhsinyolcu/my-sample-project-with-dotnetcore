using Common.Core.Helpers;
using Data.SqlServer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Framework.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<ServiceResult<T>> AddAsync(T entity);
        Task<ServiceResult<T>> UpdateAsync(T entity);
        Task<ServiceResult<int>> DeleteAsync(int id);
        Task<ServiceResult<IReadOnlyList<T>>> ListAllAsync();
    }
}
