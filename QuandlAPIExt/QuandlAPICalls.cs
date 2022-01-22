using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace QuandlAPIExt
{
  public class QuandlAPICalls
  {
    static HttpClient client = new HttpClient();
    public static async Task GetAllDataSetsInDb(string api, string dbcode)
    {
      string request = $"https://www.quandl.com/api/v3/datasets.json?database_code={dbcode}&api_key={api}";
      HttpResponseMessage response = await client.GetAsync(request);
      string content;
      if (response.IsSuccessStatusCode)
      {
        content = await response.Content.ReadAsStringAsync();
      }
    }
    public static async Task GetAllDataSetsInDbPages(string api, string dbcode, int page, int perPage)
    {
      string request = $"https://www.quandl.com/api/v3/datasets.json?database_code={dbcode}&api_key={api}&current_page={page}&per_page={perPage}";
      HttpResponseMessage response = await client.GetAsync(request);
      string content; 
      if (response.IsSuccessStatusCode)
      {
        content = await response.Content.ReadAsStringAsync();
      }
      //TODO: JsonSerialize into objects. Check Desktop for an example DataSet.
    }
  }
}
