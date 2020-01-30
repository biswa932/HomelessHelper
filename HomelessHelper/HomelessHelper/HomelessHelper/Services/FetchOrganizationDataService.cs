using HomelessHelper.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomelessHelper.Services
{
    public class FetchOrganizationDataService
    {
        public static List<Organization> Organizations { get; set; }
        public static async Task<List<Organization>> GetOrganizationDataAsync()
        {
            var url = string.Format("https://api.jsonbin.io/b/5e31c096593fd7418572a620");
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<List<Organization>>(content);
                return data;
            }
            return null;
        }
    }
}
