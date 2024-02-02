using System.Data;
using Dapper;
using NaLib.Services;

namespace NaLib;
internal class UserRepository : IRepository<Users>
{
    Repository _Repository = new Repository();
    private readonly IDbConnection connection;

    public UserRepository()
    {
         connection = _Repository.Connection;
    }
 
    public IEnumerable<Users> GetAll()
    {
        connection.Open();
        IEnumerable<Users> _Users = connection.Query<Users>("SELECT * FROM users");
        connection.Close();
        return _Users;
    }

    public void Add(Users Entity)
    {
        PasswordService _PasswordService = new PasswordService();
        connection.Open();
        connection.Execute("INSERT INTO public.users (firstname, lastname, username, email, phonenumber, role, password) VALUES(@firstname, @lastname, @username, @email, @phonenumber, @role, @password)",new Users{FirstName = Entity.FirstName, LastName = Entity.FirstName, UserName = Entity.UserName, Email = Entity.Email, Password = _PasswordService.HashPassword(Entity.Password), PhoneNumber = Entity.PhoneNumber});
        connection.Close();
    }
}