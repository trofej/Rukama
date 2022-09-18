using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Rukama.Models
{
    public class Specialization
    {
        [Display(Name = "Specialization ID")]
        public int SpecializationID { get; set; }

        public string Name { get; set; }

        public bool Checked { get; set; }


    }
}
