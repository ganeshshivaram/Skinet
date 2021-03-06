using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<IReadOnlyList<T>> ListAllAsync(ISpecification<T> specification);

        Task<T> GetEntityWithSpec(ISpecification<T> specification);

        Task<int> GetCountAsync(ISpecification<T> specification);
    }
}