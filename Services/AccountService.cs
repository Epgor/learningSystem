using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using learningSystem.Entities;
using learningSystem.Models;
using learningSystem.Exceptions;
using AutoMapper;

namespace learningSystem.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
        string GenerateJwt(LoginDto dto);
        void ChangeRole(RoleDto dto);

        UserDto GetUser(int userId);
        List<UserDto> GetUsers();
    }
    public class AccountService : IAccountService
    {
        private readonly LearningSystemDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSettings _authenticationSettings;
        private readonly IMapper mapper;

        public AccountService(LearningSystemDbContext context, IPasswordHasher<User> passwordHasher, AuthenticationSettings authenticationSettings, IMapper mapper)
        {
            _context = context;
            _passwordHasher = passwordHasher;
            _authenticationSettings = authenticationSettings;
            this.mapper = mapper;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                Name = dto.Name,
                Email = dto.Email,
                DateOfBirth = dto.DateOfBirth
            };
            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public string GenerateJwt(LoginDto dto)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Email == dto.Email);

            if (user is null)//non-null user
            {
                throw new BadRequestException("Invalid username or password");
            }
            //verify hash
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, dto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid username or password");
            }
            //claims to token
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Name}"),
                new Claim(ClaimTypes.Role, $"{user.Role.Name}")
            };
            if (user.DateOfBirth is not null)
            {
                claims.Add(new Claim("DateOfBirth", user.DateOfBirth.Value.ToString("yyyy-MM-dd")));
            }
            
            //key & credentials
            var key = new SymmetricSecurityKey(
                Encoding.UTF8
                .GetBytes(_authenticationSettings.JwtKey));
            var cred = new SigningCredentials(
                key, 
                SecurityAlgorithms.HmacSha256);
            //expiration (val's in json)
            var expires = DateTime.Now.AddDays(
                _authenticationSettings.JwtExpireDays);
            //generate token
            var token = new JwtSecurityToken(
                _authenticationSettings.JwtIssuer,
                _authenticationSettings.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: cred);
            //returning token via handler
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);

        }

        public void ChangeRole(RoleDto dto)
        {
            var user = _context
                .Users
                .FirstOrDefault(x => x.Id == dto.userId);

            if (user is null)
            {
                throw new NotFoundException("User does not exist!");
            }

            user.RoleId = dto.roleId;
            _context.SaveChanges();
        }

        public UserDto GetUser(int id)
        {
            var user = _context
                .Users
                .Include(x => x.Role)
                .FirstOrDefault(c => c.Id == id);

            if (user is null)
                throw new NotFoundException("User does not exist!");

            var userDto = mapper.Map<UserDto>(user);

            return userDto;
        }

        public List<UserDto> GetUsers()
        {
            var users = _context
                .Users
                .Include(x => x.Role);

            if (!users.Any())
                throw new NotFoundException("Empty user base!");

            var usersDto = mapper.Map<List<UserDto>>(users);

            return usersDto;

        }
    }
}
