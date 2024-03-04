using Services.Dtos;

namespace Services.Services
{
    public interface ITokenService
    {
        string CreateToken(RegisterDto user);
    }
}
