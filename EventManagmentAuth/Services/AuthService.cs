using EventManagmentAuth.Models;
using EventManagmentAuth.Services.IService;
using EventsCore.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace EventManagmentAuth.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IJwtTokenGenerator jwtTokenGenerator;
        private readonly ApplicationContext context;

        public AuthService(IJwtTokenGenerator jwtTokenGenerator, ApplicationContext context ,  UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.jwtTokenGenerator = jwtTokenGenerator;
            this.context = context;
        }

        public async Task<bool> AssignRole(string email, string role)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                if(!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                await userManager.AddToRoleAsync(user , role);
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginDTO loginUser)
        {
            var user = await userManager.FindByEmailAsync(loginUser.Email);
            bool correctPassword = await userManager.CheckPasswordAsync(user, loginUser.Password);
            if (user == null || correctPassword == false)
            {
                return new LoginResponseDto();
            }
            LoginResponseDto result = new LoginResponseDto() { 
                user = new UserDto()
                {
                    Email = loginUser.Email,
                    Id = user.Id,
                    Name = user.FullName,
                    PhoneNum = user.PhoneNumber
                }
                ,token = jwtTokenGenerator.GenerateToken(user)
            };
            return result;
        }

        public async Task<string> Register(SignUpDTO userData)
        {
            ApplicationUser user = new() {
                Email = userData.email,
                UserName = userData.email,
                FullName = userData.firstName,
                NormalizedEmail = userData.email.ToUpper(),
                NormalizedUserName = userData.email.ToUpper(),
                PhoneNumber = userData.phoneNumber,
            };
            try
            {
                var res = await userManager.CreateAsync(user, userData.password);
                ApplicationUser addedUser = await userManager.FindByEmailAsync(user.Email);
                if (res.Succeeded)
                {
                    return "Success";
                }
                else
                {
                    return res.Errors.FirstOrDefault().Description;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
