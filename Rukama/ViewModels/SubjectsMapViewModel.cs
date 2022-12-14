using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rukama.ViewModels
{
    public class SubjectsMapViewModel
    {
        public class Specialization
        {
            [Display(Name = "Specialization ID")]
            public int SpecializationID { get; set; }

            public string Name { get; set; }

            public bool Checked { get; set; }


        }

        public class Subject
        {
            [Display(Name = "Subject ID")]
            public int SubjectID { get; set; }

            [Display(Name = "Name")]
            public string SubjectName { get; set; }

            [Display(Name = "Legal Form")]
            public string LegalForm { get; set; }

            public int? CID { get; set; }

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
}
