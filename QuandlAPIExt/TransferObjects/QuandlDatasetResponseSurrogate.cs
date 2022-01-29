using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinDataApiManager.TransferObjects
{
  public class QuandlDatasetResponseSurrogate
  {
    public List<QuandlDatasetSurrogate> datasets {get; set;}
    public QuandlMetaInformationSurrogate meta {get; set;}
  }
}
