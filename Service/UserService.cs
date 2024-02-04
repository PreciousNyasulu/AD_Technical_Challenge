namespace NaLib.Services;
public class UserService
{
    private readonly IRepository<Users> _userRepository;

    public UserService(IRepository<Users> userRepository)
    {
        _userRepository = userRepository;
    }

    public void AddUser(Users user)
    {
        _userRepository.Add(user);
    }

    public IEnumerable<Users> GetAllUsers()
    {
        return _userRepository.GetAll();
    }

    public Boolean UserExists(Users User)
    {
        Console.WriteLine(_userRepository.Get(User).Count<Users>());
        return _userRepository.Get(User).Count<Users>() > 0;
    }
}