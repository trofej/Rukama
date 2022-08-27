namespace Rukama.ViewModels
{
    public class SubjectEditViewModel : SubjectCreateViewModel
    {
        public int SubjectID { get; set; }

        public string ExistingImagePath1 { get; set; }

        public string ExistingImagePath2 { get; set; }

        public string ExistingImagePath3 { get; set; }
    }
}
