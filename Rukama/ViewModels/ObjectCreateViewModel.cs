using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rukama.ViewModels
{
    public class ObjectCreateViewModel
    {

        [Display(Name = "Name")]
        public string ObjectName { get; set; }

        public string? UserID { get; set; }

        [Display(Name = "Object Type")]
        public string ObjectType { get; set; }

        public string Specialization { get; set; }

        public string Street { get; set; }

        [Display(Name = "Street Number")]
        public string StreetNr { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        [Display(Name = "Mobile Number")]
        public int? MobileNr { get; set; }

        [Display(Name = "Telephone Number")]
        public int? TelephoneNr { get; set; }
        public string? Email { get; set; }

        [Display(Name = "Website URL")]
        public string? URL { get; set; }
        public string? Comment { get; set; }

        [DisplayName("1. Image")]
        public IFormFile? Image1 { get; set; }

        [DisplayName("2. Image")]
        public IFormFile? Image2 { get; set; }

        [DisplayName("3. Image")]
        public IFormFile? Image3 { get; set; }

        [DisplayName("1. Image")]
        public string? ImagePath1 { get; set; }

        [DisplayName("2. Image")]
        public string? ImagePath2 { get; set; }

        [DisplayName("3. Image")]
        public string? ImagePath3 { get; set; }

        [Display(Name = "Created At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Modified At")]
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

    }
}
