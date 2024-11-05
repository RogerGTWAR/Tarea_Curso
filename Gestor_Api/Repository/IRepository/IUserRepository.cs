using SharedModels;

namespace Gestor_Api.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserNameAsync(string userName);
        Task<User> GetUserByIdAsync(int id);
        Task<bool> ValidateUserAsync(string userName, string password);
        Task RegisterUserAsync(User user, string password);
    }
}
