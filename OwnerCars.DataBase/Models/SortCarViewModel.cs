namespace OwnerCars.DataBase.Models
{
    public class SortCarViewModel
    {
        public SortStateCar BrandSort { get; set; }
        public SortStateCar ModelSort { get; set; }
        public SortStateCar YearSort { get; set; }
        public SortStateCar PowerSort { get; set; }
        public SortStateCar OwnerSort { get; set; }
        public SortStateCar Current { get; set; }


        public SortCarViewModel(SortStateCar sortState)
        {

            BrandSort = sortState == SortStateCar.BrandAsc ? SortStateCar.BrandDesc : SortStateCar.BrandAsc;
            ModelSort = sortState == SortStateCar.ModelAsc ? SortStateCar.ModelDesc : SortStateCar.ModelAsc;
            YearSort = sortState == SortStateCar.YearAsc ? SortStateCar.YearDesc : SortStateCar.YearAsc;
            PowerSort = sortState == SortStateCar.PowerAsc ? SortStateCar.PowerDesc : SortStateCar.PowerAsc;
            OwnerSort = sortState == SortStateCar.OwnerAsc ? SortStateCar.OwnerDesc : SortStateCar.OwnerAsc;
            Current = sortState;

        }
    }
}
