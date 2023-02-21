namespace OwnerCars.DataBase.Models
{
    public class SortOwnerViewModel
    {
        public SortStateOwner NameSort { get; set; }
        public SortStateOwner SurNameSort { get; set; }
        public SortStateOwner AgeSort { get; set; }
        public SortStateOwner Current { get; set; }

        public SortOwnerViewModel(SortStateOwner sortState)
        {
            NameSort = sortState == SortStateOwner.NameAsc ? SortStateOwner.NameDesc : SortStateOwner.NameAsc;
            SurNameSort = sortState == SortStateOwner.SurNameAsc ? SortStateOwner.SurNameDesc : SortStateOwner.SurNameAsc;
            AgeSort = sortState == SortStateOwner.AgeAsc ? SortStateOwner.AgeDesc : SortStateOwner.AgeAsc;
            Current = sortState;
        }

    }
}
