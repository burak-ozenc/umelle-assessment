using Microsoft.IdentityModel.Tokens;
using Umelle24February2023BurakOzenc.Authentication;
using Umelle24February2023BurakOzenc.Common;
using Umelle24February2023BurakOzenc.Domain;
using Umelle24February2023BurakOzenc.Helpers;
using Umelle24February2023BurakOzenc.Persistence.IRepository;

namespace Umelle24February2023BurakOzenc.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public UserService(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<string> CreateUser(UserDto userDto)
    {
        var user = User.Create(userDto.Email, userDto.Password);

        await _userRepository.AddUserAsync(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return token;
    }

    public async Task<ValidationResult> ValidateRequest(UserDto userDto)
    {
        var errors = new List<string>();

        // see Helpers.ValidationHelpers class
        if (!userDto.Email.IsValid())
        {
            errors.Add("InvalidEmail");
        }

        if (!await _userRepository.IsEmailUnique(userDto.Email))
        {
            errors.Add("DuplicateEmail");
        }

        return new ValidationResult(errors.IsNullOrEmpty(), errors);
    }
}