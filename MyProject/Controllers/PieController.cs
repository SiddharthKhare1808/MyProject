using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiddharthPieShop.Models;
using SiddharthPieShop.ViewModel;

namespace SiddharthPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IMapper mapper;
        /*private readonly ICategoryRepository _categoryRepository;*/
        /*public PieController(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;*/
        public PieController(IPieRepository pieRepository, IMapper mapper)
        {
            _pieRepository = pieRepository;
            this.mapper = mapper;
        }
        public IActionResult ListMini(int categoryId)
        {
            var pies = _pieRepository.AllPies;
            var piesmini = mapper.Map<PieMini[]>(pies);
            return View(piesmini);
        }

        /* public IActionResult List()
         {*/
        /*  //got the pie data
          var pies = _pieRepository.AllPies;

          PieListViewModel pieListViewModel = new PieListViewModel();
          pieListViewModel.Pies = pies;
          pieListViewModel.CurrentCategory = "Cheese cakes";

          //passing data to view
          return View(pieListViewModel);*/

        public async Task<ViewResult> List()
        {
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7036/api/Pie/GetAllPies"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
            }
            ViewBag.CurrentCategory = "Cheese Waffles";

            // Got the Pie Data
            /*var pies = pieRepository.AllPies;*/
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese Cake";

            // Passing data to view
            return View(pieListViewModel);
        }
        public async Task<ViewResult> PieWeek()
        {
            //got the pie data
            /*   var pies = _pieRepository.AllPies.Where(pie=>pie.IsPieOfTheWeek) ;
               //passing data t view
               return View(pies);*/
            IEnumerable<Pie> Pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7036/api/Pie/GetPieOfTheWeek"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
            }
            ViewBag.CurrentCategory = "Cheese Waffles";


            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = Pies;
            pieListViewModel.CurrentCategory = "Cheese Cake";
            return View(pieListViewModel);

        }
        public ViewResult Categories(int id)
        {
            //got the pie data
            var pies = _pieRepository.AllPies.Where(pie => pie.CategoryId == id);

            //passing data to view
            return View(pies);
            /* IEnumerable<Pie> pies;

             if (id > 0)
             {
                 pies = _pieRepository.GetCategory(id);

             }
             else
             {
                 pies = _pieRepository.AllPies;
             }
             return View(pies);
         }
 */

        }
        public ViewResult Details(int id)
        {
            //got the pie data
           var pies = _pieRepository.AllPies.FirstOrDefault(pies => pies.PieId == id);

            //passing data to view
            return View(pies);
           /* IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7036/api/Pie/Details?id="+id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
            }
            ViewBag.CurrentCategory = "Cheese Waffles";


            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese Cake";
            return View(pieListViewModel);*/

        

        }
       
        public async Task<ViewResult> FruitsPies()
        {
            // var categoryid = categoryRepostiory.AllCategories.Select(category => category.CategoryName == "Fruit pies");
            /*  var pie = _pieRepository.FruitsPies();
              return View(pie);*/
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7036/api/Pie/GetFruitPies"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
            }
            ViewBag.CurrentCategory = "Cheese Waffles";


            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese Cake";
            return View(pieListViewModel);

        }
        public async Task<ViewResult> CheesePies()
        {

            /* var pie = _pieRepository.CheesePies();
              return View(pie);*/
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7036/api/Pie/GetCheesePies"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
            }
            ViewBag.CurrentCategory = "Cheese Waffles";


            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese Cake";
            return View(pieListViewModel);

        }
        public async Task<ViewResult> SeasonalPies()
        {
            /*var pie = _pieRepository.SeasonalPies();
             return View(pie);*/
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7036/api/Pie/GetSeasonalPies"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
            }
            ViewBag.CurrentCategory = "Cheese Waffles";


            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese Cake";
            return View(pieListViewModel);
        }
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreatePie(Pie pie)
        {
             _pieRepository.CreatePie(pie);
             return RedirectToAction("List");
           /* using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("https://localhost:7036/api/Pie/InsertPie?PieId =",pie))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("List");*/





        }
    }
}

