using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinDataApiManager.TransferObjects
{
  public class QuandlDatasetSurrogate
  {
    public int id { get; set; }
    public string dataset_code { get; set; } 
    public string database_code { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public DateTime refreshed_at { get; set; }
    public DateTime newest_available_date { get; set; }
    public DateTime oldest_available_date { get; set; } 
    public List<string> column_name { get; set; }
    public string frequency { get; set; }//change to enum?
    public string type { get; set; }//change to enum?
    public bool premium { get; set; }
    public string database_id { get; set; }
  }
}
