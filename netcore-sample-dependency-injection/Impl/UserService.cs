using netcore_sample_dependency_injection.Interface;
using netcore_sample_dependency_injection.Model;

namespace netcore_sample_dependency_injection.Impl
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new();

        public async Task<IEnumerable<User>> GetAllUsersAsync() => await Task.FromResult(_users);

        public async Task<User> GetUserByIdAsync(int id) => await Task.FromResult(_users.FirstOrDefault(u => u.Id == id));

        public async Task AddUserAsync(User user)
        {
            user.Id = _users.Count + 1;
            _users.Add(user);
            await Task.CompletedTask;
        }

    }
}
