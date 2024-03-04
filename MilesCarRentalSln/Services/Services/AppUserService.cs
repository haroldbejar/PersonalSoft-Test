using Domain.Models;
using Repositories.Repositories;
using Services.Dtos;
using System.Security.Cryptography;
using System.Text;

namespace Services.Services
{
    public class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _userRepository;

        public AppUserService(IAppUserRepository  userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApplicationUserDto> GetUserByUserName(string userName)
        {
            var user = await _userRepository.GetUserByUserName(userName);
            if (user == null) return null;

            return new ApplicationUserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                PasswordSalt = user.PasswordSalt
            };
        }

        public async Task<ApplicationUserDto> Register(RegisterDto resgisterDto)
        {
            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = resgisterDto.UserName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(resgisterDto.PassWord)),
                PasswordSalt = hmac.Key
            };

            await  _userRepository.InsertAsync(user);

            return new ApplicationUserDto
            {
                UserName = resgisterDto.UserName
            };
        }

        public async Task<bool> ValidateAppUserExist(string userName)
        {
            var existengUser = await _userRepository.GetUserByUserName(userName);
            if (existengUser != null)
            {
                return true;
            }

            return false;
        }
    }
}
