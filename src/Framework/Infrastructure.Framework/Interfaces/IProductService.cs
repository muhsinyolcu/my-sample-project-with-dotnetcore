using Data.SqlServer.Entities;

namespace Infrastructure.Framework.Interfaces
{
    public interface IProductService : IAsyncRepository<MySProduct>
    {
    }
}
