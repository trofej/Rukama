using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rukama.Areas.Identity.Data;

namespace Rukama.Models
{
    public class Object
    {
        [Display(Name = "Object ID")]
        public int ObjectID { get; set; }

        [Display(Name = "Name")]
        public string ObjectName { get; set; }

        [Display(Name = "Object Type")]
        public string ObjectType { get; set; }

        public string Specialization { get; set; }

        public string GPS { get; set; }

        public string Street { get; set; }

        [Display(Name = "Street Number")]
        public string StreetNr { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string? Region { get; set; }

        [Display(Name = "Mobile Number")]
        public int? MobileNr { get; set; }

        [Display(Name = "Telephone Number")]
        public int? TelephoneNr { get; set; }

        [Display(Name = "Fax")]
        public int? FaxNr { get; set; }
        public string? Email { get; set; }

        [Display(Name = "Website URL")]
        public string? URL { get; set; }
        public string? Comment { get; set; }

        [Display(Name = "Opening Hours")]
        public string? OpeningHours { get; set; }

        [Display(Name = "Icon URL")]
        public string? IconURL { get; set; }

        [Display(Name = "1. Image URL")]
        public string? ImageURL1 { get; set; }

        [Display(Name = "2. Image URL")]
        public string? ImageURL2 { get; set; }

        [Display(Name = "3. Image URL")]
        public string? ImageURL3 { get; set; }

        [Display(Name = "Created At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Modified At")]
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        public Object()
        {

        }
    }
}