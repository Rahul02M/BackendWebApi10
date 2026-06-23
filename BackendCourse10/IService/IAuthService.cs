using BackendCourse10.Dto;

namespace BackendCourse10.IService
{
    public interface IAuthService
    {
        Task<Tuple<int, string>> LoginUser(UserDto userDto);
        Task<Tuple<int, string>> RegisterUser(RegisterUserDto userDto);
    }
}
