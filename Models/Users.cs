using System.ComponentModel.DataAnnotations;

namespace NaLib;

public class Users
{
    public int? Id { get; set; }
    
    public string? UserName { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    [EnumDataType(typeof(Roles), ErrorMessage = "Invalid value for role.")]
    public Roles Role { get; set; }

    public string? Password { get; set; }
}
