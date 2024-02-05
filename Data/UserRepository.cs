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
        string HashedPassword = _PasswordService.HashPassword(Entity.Password);
        connection.Open();
        connection.Execute("INSERT INTO public.users (firstname, lastname, username, email, phonenumber, role, password) VALUES(@firstname, @lastname, @username, @email, @phonenumber, @role, @password)",new Users{FirstName = Entity.FirstName, LastName = Entity.FirstName, UserName = Entity.UserName, Email = Entity.Email, Password = HashedPassword, PhoneNumber = Entity.PhoneNumber});
        connection.Close();
    }

    public bool Exists(Users Entity)
    {
        connection.Open();
        int Count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM users Where email=@Email", new Users{Email = Entity.Email} );
        connection.Close();
        return Count > 0;
    }

    public IEnumerable<Users> Get(Users Entity)
    {
        connection.Open();
        IEnumerable<Users> User = connection.Query<Users>("SELECT * FROM users where email=@Email", new Users { Email = Entity.Email });
        connection.Close();
        return User;
    }

    public IEnumerable<Users> Update(Users Entity)
    {
        throw new NotImplementedException();
    }
}