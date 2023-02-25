using Microsoft.EntityFrameworkCore;
using Umelle24February2023BurakOzenc.Domain;
using Umelle24February2023BurakOzenc.Persistence.IRepository;

namespace Umelle24February2023BurakOzenc.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _dbContext;

    public UserRepository(UserDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddUserAsync(User user)
    {
        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsEmailUnique(string email)
    {
        return await _dbContext.Users?.FirstOrDefaultAsync(u => u.Email == email)! == null;
    }
}