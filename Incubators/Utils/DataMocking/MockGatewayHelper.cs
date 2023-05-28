using System.Diagnostics;
using System.Text.Json;

using Utils.Exceptions;


namespace Utils.DataMocking;


public abstract class MockGatewayHelper
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
  

  /* === Localization =============================================================================================== */
  public interface ILocalization
  {

    public abstract class ErrorSimulationCompletedLog
    {
      public struct TemplateParameters
      {
        public required string GatewayName { get; init; }
        public required string TransactionName { get; init; }
      }
    }
    
    public Func<ErrorSimulationCompletedLog.TemplateParameters, string> GenerateErrorSimulationCompletedLog { get; }


    public abstract class DataRetrievingSimulationCompletedLog
    {
      public struct TemplateParameters
      {
        public required string GatewayName { get; init; }
        public required string TransactionName { get; init; }
        public string? FormattedRequestParameters { get; init; }
        public string? FormattedResponseData { get; init; }
      }
    }
    
    public Func<DataRetrievingSimulationCompletedLog.TemplateParameters, string> GenerateDataRetrievingSimulationCompletedLog { get; }
    
    
    public abstract class DataSubmittingSimulationCompletedLog
    {
      public struct TemplateParameters
      {
        public required string GatewayName { get; init; }
        public required string TransactionName { get; init; }
        public string? FormattedRequestData { get; init; }
        public string? FormattedResponseData { get; init; }
      }
    }
    
    public Func<DataSubmittingSimulationCompletedLog.TemplateParameters, string> GenerateDataSubmittingSimulationCompletedLog { get; }
    
  }

  public static ILocalization Localization = new MockGatewayHelperEnglishLocalization();


  /* === Public methods ============================================================================================= */
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
      throw new DataRetrievingFailedException(
        Localization.GenerateErrorSimulationCompletedLog(
          new ILocalization.ErrorSimulationCompletedLog.TemplateParameters
          {
            GatewayName = options.GatewayName,
            TransactionName = options.TransactionName
          }  
        )
      );
    }


    TResponseData responseData = getResponseData();

    Debug.WriteLine(
      Localization.GenerateDataRetrievingSimulationCompletedLog(
        new ILocalization.DataRetrievingSimulationCompletedLog.TemplateParameters
        {
          GatewayName = options.GatewayName,
          TransactionName = options.TransactionName,
          FormattedRequestParameters = System.Text.Json.JsonSerializer.Serialize(
            requestParameters, new JsonSerializerOptions { WriteIndented = true}
          ),
          FormattedResponseData = options.MustLogResponseData ? 
              System.Text.Json.JsonSerializer.Serialize(
                responseData, new JsonSerializerOptions { WriteIndented = true}
              ) :
              null
        }
      )
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
      throw new DataRetrievingFailedException(
        Localization.GenerateErrorSimulationCompletedLog(
          new ILocalization.ErrorSimulationCompletedLog.TemplateParameters
          {
            GatewayName = options.GatewayName,
            TransactionName = options.TransactionName
          }  
        )
      );
    }


    TResponseData responseData = getResponseData();

    Debug.WriteLine(
      Localization.GenerateDataSubmittingSimulationCompletedLog(
        new ILocalization.DataSubmittingSimulationCompletedLog.TemplateParameters()
        {
          GatewayName = options.GatewayName,
          TransactionName = options.TransactionName,
          FormattedRequestData = System.Text.Json.JsonSerializer.Serialize(
            requestData, new JsonSerializerOptions { WriteIndented = true}
          ),
          FormattedResponseData = options.MustLogResponseData ?
              System.Text.Json.JsonSerializer.Serialize(
                responseData, new JsonSerializerOptions { WriteIndented = true}
              ) :
              null
        }  
      )
    );

    return responseData;
    
  }
  
}
