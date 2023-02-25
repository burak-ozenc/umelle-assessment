using Umelle24February2023BurakOzenc.Domain;

namespace Umelle24February2023BurakOzenc.Persistence.IRepository;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<bool> IsEmailUnique(string email);
}