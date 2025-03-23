using netcore_sample_dependency_injection.Model;

namespace netcore_sample_dependency_injection.Interface
{

    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task AddUserAsync(User user);
    }
}
