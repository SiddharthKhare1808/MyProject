namespace SiddharthPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly AppDbContext appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies => appDbContext.Pies;
            

        public IEnumerable<Pie> PiesOfTheWeek => appDbContext.Pies.Where(pie=>pie.IsPieOfTheWeek);
        public IEnumerable<Pie> FruitsPies()
        {
            return AllPies.Where(pie => pie.CategoryId == 1);
        }
        public IEnumerable<Pie> CheesePies()
        {
            return AllPies.Where(pie => pie.CategoryId == 2);
        }
        public IEnumerable<Pie> SeasonalPies()
        {
            return AllPies.Where(pie => pie.CategoryId == 3);
        }

        public Pie GetPieById(int pieId)
        {
            return this.AllPies.FirstOrDefault(p => p.PieId == pieId);
        }

        public int CreatePie(Pie pie)
        {
            appDbContext.Pies.Add(pie);
            return appDbContext.SaveChanges();
        }
        public int RemovePie(Pie pie)
        {
            appDbContext.Pies.Remove(pie);
            return appDbContext.SaveChanges();
        }
        public int UpdatePie(Pie pie)
        {
            appDbContext.Pies.Update(pie);
            return appDbContext.SaveChanges();
        }

    }
}
