using ConAPI.Domain;

namespace ConAPI.Repositories;

public interface IUserRepository
{
    Task<int> CreateUser(User usr);
}