using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using ScaffelPikeContracts.Heartbeat;
using ScaffelPikeContracts.LogIn;
using ScaffelPikeContracts.Quandl;
using ScaffelPikeContracts.Yahoo;
using YahooFinanceApi;

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
    Task<List<QuandlDatabaseResponse>> GetQuandlDbs();

    [OperationContract]
    Task<List<QuandlDatasetResponse>> GetQuandlDataSets(string dbCode);

    [OperationContract]
    Task<QuandlTimeseriesDataResponse> GetQuandlTimeseries(string dbCode , string dsCode);
    [OperationContract]
    Task<YahooSecurityResponse> QueryYahoo(Field[] fields, params string[] tickers);
    [OperationContract]
    Task<List<string>> GetYahooTickers();
    [OperationContract]
    Task<List<YahooCandleResponse>> GetYahooHistoricalData(string symbol, DateTime? startTime = null, DateTime? endTime = null, Period period = Period.Daily);
  }
}
