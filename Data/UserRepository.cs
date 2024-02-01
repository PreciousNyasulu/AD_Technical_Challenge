using System.Data;
using Dapper;

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
}