using Newtonsoft.Json;
using Utils.Exceptions;


namespace MockDataSource.Utils;


internal abstract class MockGatewayHelper
{

  private const byte MINIMAL_PENDING_PERIOD__SECONDS = 1;
  private const byte MAXIMAL_PENDING_PERIOD__SECONDS = 2;

  public class SimulationOptions
  {
    public byte MinimalPendingPeriod__Seconds = MINIMAL_PENDING_PERIOD__SECONDS;
    public byte MaximalPendingPeriod__Seconds = MAXIMAL_PENDING_PERIOD__SECONDS;
    public bool MustSimulateError = false;
    public string GatewayName;
    public string TransactionName;
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

    Console.WriteLine(
      $"{options.GatewayName}.{options.TransactionName}、下記のリクエスト引数付きのデータ仮取得完了。\n" +
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

    Console.WriteLine(
      $"{options.GatewayName}.{options.TransactionName}、下記のリクエストデータの仮送信完了。\n" +
      JsonConvert.SerializeObject(requestData)
    );

    return responseData;
  }
}
