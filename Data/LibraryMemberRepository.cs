using NaLib.Models;
using System.Data;
using Dapper;
using NaLib.Services;
using System.Collections;

namespace NaLib.Data;

public class LibraryMemberRepository : IRepository<LibraryMember>
{
    Repository _Repository = new Repository();
    private readonly IDbConnection connection;

    public LibraryMemberRepository()
    {
        connection = _Repository.Connection;
    }

    public void Add(LibraryMember entity)
    {
        connection.Open();
        string query = "INSERT INTO members (first_name, last_name, email, phone_number, address, registration_date) " +
                       "VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Address, @RegistrationDate)";

        connection.Execute(query, entity);
        connection.Close();
    }

    public bool Exists(LibraryMember entity)
    {
        connection.Open();
        string query = "SELECT COUNT(*) FROM members WHERE email = @Email";
        int count = connection.QuerySingle<int>(query, entity);
        connection.Close();
        return count > 0;
    }

    public IEnumerable<LibraryMember> Get(LibraryMember Entity)
    {
        connection.Open();
        string query = "SELECT * FROM members WHERE email = @Email or member_id = @MemberId";
        return connection.Query<LibraryMember>(query, Entity);
    }

    public IEnumerable<LibraryMember> GetAll()
    {
        connection.Open();
        string query = "SELECT * FROM members";
        return connection.Query<LibraryMember>(query);
    }

    public IEnumerable<LibraryMember> Update(LibraryMember Entity)
    {
        connection.Open();
        string query = "UPDATE members SET first_name = @FirstName, last_name = @LastName, " +
                       "email = @Email, phone_number = @PhoneNumber, address = @Address, registration_date = @RegistrationDate " +
                       "WHERE member_id = @MemberId";

        connection.Execute(query, Entity);
        connection.Close();
        return new List<LibraryMember> { Entity };
    }
}
