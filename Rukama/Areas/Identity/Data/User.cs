using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Rukama.Models;

namespace Rukama.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class User : IdentityUser
{

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Nickname { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string Surname { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(2048)")]
    public string? AvatarUrl { get; set; }

}

