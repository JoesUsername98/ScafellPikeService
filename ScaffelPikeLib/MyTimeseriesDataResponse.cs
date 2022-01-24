using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Quandl.NET;

namespace ScaffelPikeContracts
{
  [DataContract]
  public class MyTimeseriesDataResponse
  {
    public MyTimeseriesDataResponse(Quandl.NET.Model.TimeseriesData data)
    {
      Limit = data.Limit;
      Transform = data.Transform; 
      ColumnIndex =  data.ColumnIndex;
      ColumnNames = data.ColumnNames;
      StartDate = data.StartDate;
      EndDate = data.EndDate;
      Frequency = data.Frequency;
      Data = data.Data;
      Collapse = data.Collapse;
      Order = data.Order;
    }
    [DataMember]
    public int? Limit {
      get;
      private set;
    }
    [DataMember]
    public Transform? Transform {
      get;
      private set;
    }
    [DataMember]
    public int? ColumnIndex {
      get;
      private set;
    }
    [DataMember]
    public List<string> ColumnNames {
      get;
      private set;
    }
    [DataMember]
    public DateTime? StartDate {
      get;
      private set;
    }
    [DataMember]
    public DateTime? EndDate {
      get;
      private set;
    }
    [DataMember]
    public string Frequency {
      get;
      private set;
    }
    [DataMember]
    public List<object[]> Data {
      get;
      private set;
    }
    [DataMember]
    public Collapse? Collapse {
      get;
      private set;
    }
    [DataMember]
    public Order? Order {
      get;
      private set;
    }
  }
}
