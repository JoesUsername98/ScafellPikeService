using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Quandl.NET;
using Quandl.NET.Model;

namespace ScafellPikeContracts.Quandl
{
  [DataContract]
  public class QuandlTimeseriesDataResponse
  {
    public QuandlTimeseriesDataResponse(TimeseriesData data)
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
