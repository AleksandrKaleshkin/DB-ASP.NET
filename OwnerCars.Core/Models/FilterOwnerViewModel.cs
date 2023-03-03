namespace OwnerCars.Core.Models
{
    public class FilterOwnerViewModel
    {
        public FilterOwnerViewModel(string name, string surname, int age) {
            SelectedName = name;
            SelectedSurName = surname;
            SelectedAge = age;

        }

        public string SelectedName { get; set; }
        public string SelectedSurName { get; set; }
        public int SelectedAge { get; set; }
    }


}
