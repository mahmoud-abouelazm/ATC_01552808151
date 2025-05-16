using EventManagmentAuth.Models;

namespace EventManagmentAuth.Services.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser user);
    }
}
