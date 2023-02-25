using Umelle24February2023BurakOzenc.Common;

namespace Umelle24February2023BurakOzenc.Services;

public interface IUserService
{
    Task<string> CreateUser(UserDto userDto);

    Task<ValidationResult> ValidateRequest(UserDto userDto);
}