using AuthenticationAPI.Models;

namespace AuthenticationAPI.Service.IService
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IList<string> role);
    }
}
