using System.ComponentModel.DataAnnotations;

namespace Rukama.Models
{
    public class LegalForm
    {
        [Display(Name = "LegalForm ID")]
        public int LegalFormID { get; set; }

        public string Name { get; set; }
    }
}
