using FitnessClubCopy.Models;
using FitnessClubCopy.ViewModels;

namespace FitnessClubCopy.Repositories
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginViewModel model);
        Task<Status> RegisterAsync(RegisterViewModel model);
        Task LogoutAsync();
    }
}
