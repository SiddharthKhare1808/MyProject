namespace PieShopAPI.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        IEnumerable<Pie> SeasonalPies();
        IEnumerable<Pie> FruitsPies();
        IEnumerable<Pie> CheesePies();


        Pie InsertPie(Pie pie);
        Pie UpdatePie(Pie pie);
        Pie DeletePie(int pieId);
    


    Pie GetPieById(int pieId);

    }
}
