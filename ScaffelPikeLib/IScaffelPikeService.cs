using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using Quandl.NET.Model.Response;

namespace ScaffelPikeContracts
{
  [ServiceContract(Namespace = "http://ScaeffelPike.Service")]
  public interface IScaffelPikeService
  {
    [OperationContract]
    Task<LogInResponse> LogIn(LogInRequest request);

    [OperationContract]
    Task<HeartbeatDto> Heartbeat(HeartbeatDto heartbeat);

    [OperationContract]
    Task<List<DatabaseResponse>> GetQuandlDbs();

    [OperationContract]
    Task<List<DatasetResponse>> GetQuandlDataSets(string dbCode);

    [OperationContract]
    Task<MyTimeseriesDataResponse> GetQuandlTimeseries(string dbCode , string dsCode);
  }
}
