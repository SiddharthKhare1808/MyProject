using Newtonsoft.Json;

namespace PieShopAPI.Models
{
   /* public static class APIClass
    {
        public static async Task<IEnumerable<Pie>> GetApidata(string APIAddress)
        {
            IEnumerable<Pie> students = new List<Pie>();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(APIAddress))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
            }
            return students;
        }
    }*/
}
