using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Rukama.ViewModels
{
    public class UserViewModel
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
        public IFormFile? Avatar { get; set; }
    }
}
