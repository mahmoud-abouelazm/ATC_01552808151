using EventsCore.DTO;

namespace EventManagmentAuth.Services.IService
{
    public interface IAuthService
    {
        Task<string> Register(SignUpDTO user);
        Task<LoginResponseDto> Login(LoginDTO user);
        Task<bool> AssignRole(string email , string role);
    }
}
