using System.ComponentModel.DataAnnotations;

namespace Rukama.Models
{
    public class ObjectType
    {
        [Display(Name = "ObjectType ID")]
        public int ObjectTypeID { get; set; }

        public string Name { get; set; }

    }
}
