﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rukama.Areas.Identity.Data;

namespace Rukama.Models
{
    public class Subject
    {
        [Display(Name = "Subject ID")]
        public int SubjectID { get; set; }

        [Display(Name = "Name")]
        public string SubjectName { get; set; }

        [Display(Name = "Legal Form")]
        public string LegalForm { get; set; }

        public int CID { get; set; }

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

        [DisplayName("Icon")]
        public string? Icon { get; set; }

        [DisplayName("1. Image")]
        public string ImagePath1 { get; set; }

        [DisplayName("2. Image")]
        public string ImagePath2 { get; set; }

        [DisplayName("3. Image")]
        public string ImagePath3 { get; set; }

        [Display(Name = "Created At")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }

        [Display(Name = "Modified At")]
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public Subject()
        {

        }


    }
}