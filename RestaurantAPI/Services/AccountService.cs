using Microsoft.AspNetCore.Identity;
using RestaurantAPI.Data;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        public AccountService(RestaurantDbContext dbContext, IPasswordHasher<User> passowrdHasher)
        {
            _passwordHasher = passowrdHasher;
            _dbContext = dbContext;
        }

        public void RegisterUser(RegisterUserDto dto)
        {

            var newUser = new User()
            {
                Email = dto.Email,
                DateOfBirth = dto.DateofBirth,
                Nationality = dto.Nationality,
                RoleId = dto.RoleId,
            };

            var hashedPassword =_passwordHasher.HashPassword(newUser, dto.Password);
            newUser.PassworHash = hashedPassword;

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
            
        }

    }
}
