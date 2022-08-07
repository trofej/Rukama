using System.ComponentModel.DataAnnotations;

namespace Rukama.Models
{
    public class Establishment
    {
        [Key]
        [Display(Name = "Enrollment ID")]
        public int EnrollmentID { get; set; }

        [Display(Name = "Object ID")]
        public int? ObjectID { get; set; }
        public virtual Object Object { get; set; }

        public Establishment()
        {

        }

    }
}
