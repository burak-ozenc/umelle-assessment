using Umelle24February2023BurakOzenc.Domain;

namespace Umelle24February2023BurakOzenc.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}