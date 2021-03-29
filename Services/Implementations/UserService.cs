using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Core.Middleware;
using Core.Utils;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly IOptions<AuthOptions> _authOptions;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UsersService(Context context, IMapper mapper, IOptions<AuthOptions> authOption, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _authOptions = authOption;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Register(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var userProfile = _mapper.Map<UserProfile>(userDto);

            user.UserProfile = userProfile;
            _context.Add(user);
            _context.Add(userProfile);
            await _context.SaveChangesAsync();

        }
        public async Task<string> Login(CredentialsDto credentials)
        {
            var user = await Authenticate(credentials);
            if (user == null)
                throw new UnauthorizedAccessException();
            return GenerateJWT(user);
        }
        private async Task<User> Authenticate(CredentialsDto credentials)
        {
            return await _context.Users.Where(u => u.Email.Equals(credentials.Email) && u.Password.Equals(credentials.Password)).FirstOrDefaultAsync();
        }
        private string GenerateJWT(User user)
        {
            if (user == null)
                throw new ArgumentNullException();
            var authParams = _authOptions.Value;
            var secret = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                };

            var token = new JwtSecurityToken(authParams.Issuer, authParams.Audience, claims, expires: DateTime.Now.AddSeconds(authParams.TokenLifetime), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<UserDto> GetUserPreferences()
        {
            var userEmail = _httpContextAccessor.GetCurrenUserEmail();
            return _mapper.Map<UserDto>(await _context.Users.Include(u => u.UserProfile).FirstOrDefaultAsync(u => u.Email.Equals(userEmail)));
        }
    }
}

