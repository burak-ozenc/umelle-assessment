using System.Net.Mail;

namespace Umelle24February2023BurakOzenc.Helpers;

public static class ValidationHelpers
{
    public static bool IsValid(this string email)
    {
        try
        {
            MailAddress m = new MailAddress(email);

            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}