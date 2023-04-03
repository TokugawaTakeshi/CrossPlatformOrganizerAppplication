using System.Diagnostics;
using Newtonsoft.Json;
using Utils.Exceptions;


namespace MockDataSource.Utils;


internal abstract class MockGatewayHelper
{

  private const ushort MINIMAL_PENDING_PERIOD__SECONDS = 1;
  private const ushort MAXIMAL_PENDING_PERIOD__SECONDS = 2;

  public class SimulationOptions
  {
    public ushort MinimalPendingPeriod__Seconds { get; init; } = MINIMAL_PENDING_PERIOD__SECONDS;
    public ushort MaximalPendingPeriod__Seconds { get; init; } = MAXIMAL_PENDING_PERIOD__SECONDS;
    public bool MustSimulateError { get; init; }
    public bool MustLogResponseData { get; init; }
    public required string GatewayName { get; init; }
    public required string TransactionName { get; init; }
  }


  public static async Task<TResponseData> SimulateDataRetrieving<TRequestParameters, TResponseData>(
    TRequestParameters requestParameters,
    Func<TResponseData> getResponseData,
    SimulationOptions options
  )
  {

    await Task.Delay(new Random(DateTime.Now.Millisecond).Next(
      minValue: (int)TimeSpan.FromSeconds(options.MinimalPendingPeriod__Seconds).TotalMilliseconds,
      maxValue: (int)TimeSpan.FromSeconds(options.MaximalPendingPeriod__Seconds).TotalMilliseconds
    ));

    if (options.MustSimulateError)
    {
      throw new DataRetrievingFailedException();
    }


    TResponseData responseData = getResponseData();

    Debug.WriteLine(
      $"{ options.GatewayName }.{ options.TransactionName }、下記のリクエスト引数付きのデータ仮取得完了。\n" +
      JsonConvert.SerializeObject(requestParameters)
    );

    return responseData;
  }

  public static async Task<TResponseData> SimulateDataSubmitting<TRequestData, TResponseData>(
    TRequestData requestData,
    Func<TResponseData> getResponseData,
    SimulationOptions options
  )
  {

    await Task.Delay(new Random(DateTime.Now.Millisecond).Next(
      minValue: (int)TimeSpan.FromSeconds(options.MinimalPendingPeriod__Seconds).TotalMilliseconds,
      maxValue: (int)TimeSpan.FromSeconds(options.MaximalPendingPeriod__Seconds).TotalMilliseconds
    ));

    if (options.MustSimulateError)
    {
      throw new DataSubmittingFailedException();
    }


    TResponseData responseData = getResponseData();

    Debug.WriteLine(
      $"{options.GatewayName}.{options.TransactionName}、下記のリクエストデータの仮送信完了。\n" +
      JsonConvert.SerializeObject(requestData)
    );

    return responseData;
  }
  
}
