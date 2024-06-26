﻿using JWT_Authorization_Authentication.Context;
using JWT_Authorization_Authentication.Interfaces;
using JWT_Authorization_Authentication.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT_Authorization_Authentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(JwtContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public Role AddRole(Role role)
        {
            var addedRole = _context.Roles.Add(role);
            _context.SaveChanges();

            return addedRole.Entity;
        }

        public User AddUser(User user)
        {
            var addedUser = _context.Users.Add(user);
            _context.SaveChanges();

            return addedUser.Entity;
        }

        public bool AssignRoleToUser(AddUserRole obj)
        {
            try
            {
                var addRoles = new List<UserRole>();

                var user = _context.Users.SingleOrDefault(s => s.Id == obj.UserId);

                if (user == null)
                {
                    throw new Exception("User not valid");
                }

                foreach (int role in obj.RoleIds)
                {
                    var userRole = new UserRole();
                    userRole.RoleId = role;
                    userRole.UserId = user.Id;

                    addRoles.Add(userRole);
                }

                _context.UserRoles.AddRange(addRoles);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
           
        }

        public string Login(LoginRequest loginRequest)
        {
            if (loginRequest.Username != null && loginRequest.Password != null)
            {
                var user = _context.Users.SingleOrDefault(s => s.Username == loginRequest.Username && s.Password == loginRequest.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["JWT:Subject"]), //check here for error Jwt
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Username", user.Name)
                    };

                    var userRoles = _context.UserRoles.Where(u => u.UserId == user.Id).ToList();
                    var roleIds = userRoles.Select(s => s.RoleId).ToList();
                    var roles = _context.Roles.Where(r => roleIds.Contains(r.Id)).ToList();

                    foreach (var role in roles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Name));
                    }

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                            _configuration["JWT:Issuer"],
                            _configuration["JWT:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn
                        );

                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return jwtToken;
                }
                else
                {
                    throw new Exception("User is not valid");
                }
            }
            else
            {
                throw new Exception("Credentials are not valid");
            }
        }
    }
}
