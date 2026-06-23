using BackendCourse10.Data;
using BackendCourse10.Dto;
using BackendCourse10.IService;
using BackendCourse10.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BackendCourse10.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Tuple<int, string>> LoginUser(UserDto userDto)
        {
            try
            {
                var existingUser = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == userDto.Email);

                if (existingUser == null)
                {
                    return new Tuple<int, string>(0, "This User Not Exist");
                }

                //if (existingUser.Password != userDto.Password)
                //{
                //    return new Tuple<int, string>(1, "User Email and Password Incorrect");
                //}

                var passwordHasher = new PasswordHasher<string>();
                var verifyPassword = passwordHasher.VerifyHashedPassword(
                    userDto.Email,
                    existingUser.Password,
                    userDto.Password
                );
                if (verifyPassword == PasswordVerificationResult.Success)
                {
                    return new Tuple<int, string>(2, "Login Successfull");
                }
                else if (verifyPassword == PasswordVerificationResult.SuccessRehashNeeded)
                {
                     existingUser.Password = PasswordHashing(
                         userDto.Email,
                         userDto.Password
                     );
                    _context.Users.Update(existingUser);
                    _context.SaveChanges();

                    return new Tuple<int, string>(2, "Login Successfull, New Hash Genrated");
                }
                else if (verifyPassword == PasswordVerificationResult.Failed)
                {
                    return new Tuple<int, string>(1, "Password Incorrect");
                }

                return new Tuple<int, string>(1, "Password Incorrect");
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<Tuple<int, string>> RegisterUser(RegisterUserDto userDto)
        {
            try
            {
                var existingUser = await _context.Users.AnyAsync(x => x.Email == userDto.Email);
                if (existingUser)
                {
                    return new Tuple<int, string>(0, "This User is already Exist, Please Register with New User!");
                }

                _context.Users.Add(new User
                {

                    Id = Guid.NewGuid(),
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = PasswordHashing(
                        userDto.Email,
                        userDto.Password
                    )

                });

                await _context.SaveChangesAsync();

                return new Tuple<int, string>(1, "User Register Successfully");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private string PasswordHashing(string email, string password)
        {
            var passwordHasher = new PasswordHasher<string>();
            return passwordHasher.HashPassword(email, password);
        }

    }
}
