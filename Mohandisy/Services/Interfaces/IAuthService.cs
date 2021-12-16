using System.Threading.Tasks;
using Mohandisy.Models;

namespace Mohandisy.Services
{
    public interface IAuthService
    {
        Task<AuthModel> RegisterAsync(RegisterModel model, string roleName);
        Task<AuthModel> RegisterAdminAsync(RegisterModel model, string type);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);
        bool CheckRole(string id);
        string GetRoleName(string id);
    }
}