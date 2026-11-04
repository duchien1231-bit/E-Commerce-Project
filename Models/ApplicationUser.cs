using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ECommerceProject.Models;

public class ApplicationUser : IdentityUser
{
    [Required, StringLength(100)]
    public string DisplayName { get; set; } = string.Empty;
}
