﻿using SiddharthPieShop.Models;

namespace SiddharthPieShop.ViewModel
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; set; }

        public string CurrentCategory { get; set; }

    }
}
