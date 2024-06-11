using JWT_Authorization_Authentication.Models;

namespace JWT_Authorization_Authentication.Interfaces
{
    public interface IAuthService
    {
        public User AddUser(User user);

        public string Login(LoginRequest loginRequest);

        public Role AddRole(Role role);

        public bool AssignRoleToUser(AddUserRole obj);
    }
}
