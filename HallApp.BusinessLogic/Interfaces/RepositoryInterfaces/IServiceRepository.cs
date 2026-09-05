using HallApp.Entities.DatabaseEntities;

namespace HallApp.BusinessLogic.Interfaces.RepositoryInterfaces;

public interface IServiceRepository
{
    Task<ICollection<ServiceEntity>> GetByIdsAsync(IEnumerable<int> ids);
}
