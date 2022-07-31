using AutoMapper;

namespace SiddharthPieShop.Models
{
    public class PieProfile:Profile 
    {
        public PieProfile()
        {
            this.CreateMap<Pie, PieMini>();
        }

    }
}
