using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaffelPikeContracts
{
  public class DatasetResponse
  {
    public int Id { get; set; }
    public string Code { get; set; }
    public string DatabaseCode { get; set; }
    public string DatabaseId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime RefreshedAt { get; set; }
    public List<string> ColumnName { get; set; }
    public string Frequency { get; set; }//change to enum?
    public string Type { get; set; }//change to enum?
  }
}
