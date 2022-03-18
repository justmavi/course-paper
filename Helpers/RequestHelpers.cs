using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;

namespace CoursePaper.Helpers
{
    public static class RequestHelpers
    {
        public static async Task<string> GetCurrencyRates(string from, string[] to)
        {
            string url = ConfigurationManager.AppSettings["currency_api_url"];

            var builder = new UriBuilder(url);
            var queryParams = HttpUtility.ParseQueryString(builder.Query);

            queryParams["api_key"] = ConfigurationManager.AppSettings["currency_api_key"];
            queryParams[nameof(from)] = from;
            queryParams[nameof(to)] = string.Join(",", to);

            builder.Query = queryParams.ToString();

            using (var client = new HttpClient()) 
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = builder.Uri
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }
    }
}
