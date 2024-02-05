using NaLib.Models;

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
        return _userRepository.Get(User).Count<Users>() > 0;
    }

    public Users GetUser(Users User)
    {
         return _userRepository.Get(User).FirstOrDefault();
    }

    public LoginStatus ConfirmUser(Users User)
    {
        if(!UserExists(User))
        {
            return LoginStatus.NotFound;   
        }
        Users _User = GetUser(User);
        PasswordService passwordService = new PasswordService();
        bool PasswordVerification = passwordService.VerifyPassword(storedPassword: _User.Password, providedPassword: User.Password);
        
        if(!PasswordVerification)
        {
            return LoginStatus.IncorrectPassword;
        }

        return LoginStatus.Success;
    }
}