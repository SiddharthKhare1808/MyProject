namespace SiddharthPieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies { get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        IEnumerable<Pie> SeasonalPies();
        IEnumerable<Pie> FruitsPies();
        IEnumerable<Pie> CheesePies();

        int UpdatePie(Pie pie);
        int CreatePie(Pie pie);
        int RemovePie(Pie pie);





        Pie GetPieById(int pieId);

    }
}
