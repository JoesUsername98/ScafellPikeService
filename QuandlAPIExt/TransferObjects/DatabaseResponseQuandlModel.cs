using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuandlAPIExt.TransferObjects
{
  public class DatabaseResponseQuandlModel
  {
    public List<DatabaseQuandlModel> databases { get; set; }
    public MetaInformationQuandlModel meta { get; set; }
  }
}
