using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinDataApiManager.TransferObjects
{
  public class QuandlDatabaseResponseSurrogate
  {
    public List<QuandlDatabaseSurrogate> databases { get; set; }
    public QuandlMetaInformationSurrogate meta { get; set; }
  }
}
