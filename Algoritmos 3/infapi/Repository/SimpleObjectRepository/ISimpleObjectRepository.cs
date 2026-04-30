using ConAPI.Domain;

namespace ConAPI.Repositories;

public interface ISimpleObjectRepository
{
    Task<IEnumerable<SimpleObject>> GetObjects();

    Task<int> InsertObject(SimpleObject simpleObject);
}