using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Entities;

public class UserEntity : IdentityUser
{
    [ProtectedPersonalData]
    public string FirstName { get; set; } = null!;

    [ProtectedPersonalData]
    public string LastName { get; set; } = null!;

    [ProtectedPersonalData]
    public string? Bio {  get; set; }

    [ProtectedPersonalData]
    public string? ProfileImage { get; set; } = "~/images/Avatar1.jpg";

    public int? AddressId { get; set; }
    public AddressEntity? Address { get; set; }
}

