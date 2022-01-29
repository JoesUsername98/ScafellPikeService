using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinDataApiManager.TransferObjects
{
  public class QuandlDatabaseSurrogate
  {
    public int id { get; set; }
    public string name { get; set; }
    public string database_code { get; set; }
    public string description { get; set; }
    public int datasets_count { get; set; }
    public long downloads { get; set; }
    public bool premium { get; set; }
    public string image { get; set; }
    public bool favorite { get; set; }
    public string url_name { get; set; }
    public bool exclusive { get; set; }
  }
}
