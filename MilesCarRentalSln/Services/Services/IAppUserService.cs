using Services.Dtos;

namespace Services.Services
{
    public interface IAppUserService
    {
        Task<ApplicationUserDto> GetUserByUserName(string userName);
        Task<ApplicationUserDto> Register(RegisterDto resgisterDto);
        Task<bool> ValidateAppUserExist(string userName);
    }
}
