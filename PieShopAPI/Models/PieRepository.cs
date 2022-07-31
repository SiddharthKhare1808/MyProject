namespace PieShopAPI.Models
{
    public class PieRepository:IPieRepository
    {
        private readonly AppDbContext appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IEnumerable<Pie> AllPies => appDbContext.Pies;


        public IEnumerable<Pie> PiesOfTheWeek => appDbContext.Pies.Where(pie => pie.IsPieOfTheWeek);
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

        public Pie InsertPie(Pie pie)
        {
          
                var entry = this.appDbContext.Pies.Add(pie);
                this.appDbContext.SaveChanges();
                return entry.Entity;
            



          
        }

        public Pie UpdatePie(Pie pie)
        {
            var entry = this.appDbContext.Pies.Update(pie);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }

        public Pie DeletePie(int pieId)
        {
            var pie = AllPies.FirstOrDefault(pie => pie.PieId == pieId);
            var entry = this.appDbContext.Pies.Remove(pie);
            this.appDbContext.SaveChanges();
            return entry.Entity;
        }
    }
}
