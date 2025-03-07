using MAUITestAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITestAPI.Services {
    public class APIService {
        public async Task<Root> getNews(string category) {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?category={category.ToLower()}&apikey=859c96bceecbbd8f9323d201a49d9711&lang=en");
            return JsonConvert.DeserializeObject<Root>(response);
        }
    }
}
