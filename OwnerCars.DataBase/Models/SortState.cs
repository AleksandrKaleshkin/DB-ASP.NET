
namespace OwnerCars.DataBase.Models
{
    public enum SortStateOwner
    {
        NameAsc,    // по имени по возрастанию
        NameDesc,   // по имени по убыванию
        SurNameAsc,    // по фамилии по возрастанию
        SurNameDesc,   // по фамилии по убыванию
        AgeAsc, // по возрасту по возрастанию
        AgeDesc    // по возрасту по убыванию

    }

    public enum SortStateCar
    {
        BrandAsc, // по марке по возрастанию
        BrandDesc, // по марке по убыванию
        ModelAsc, // по моделе по возрастанию
        ModelDesc, // по моделе по убыванию
        YearAsc, // по году по возрастанию
        YearDesc, // по году по убыванию
        PowerAsc, // по мощности по возрастанию
        PowerDesc, // по мощности по убыванию
        OwnerAsc, // по владельцу по возрастанию
        OwnerDesc // по владельцу по убыванию
    }
}
