namespace Utils.DataMocking;


public struct MockGatewayHelperEnglishLocalization: MockGatewayHelper.ILocalization
{

  public Func<MockGatewayHelper.ILocalization.ErrorSimulationCompletedLog.TemplateParameters, string>
      GenerateErrorSimulationCompletedLog =>
          (MockGatewayHelper.ILocalization.ErrorSimulationCompletedLog.TemplateParameters templateParameters) =>
              $"Class \"MockGatewayHelper\" has simulated the error for the transaction " +
                  $"\"{templateParameters.GatewayName}.{templateParameters.TransactionName}\" because the option " +
                  $"\"MustSimulateError\" has been set to true.";

  public Func<MockGatewayHelper.ILocalization.DataRetrievingSimulationCompletedLog.TemplateParameters, string> 
      GenerateDataRetrievingSimulationCompletedLog =>
          (MockGatewayHelper.ILocalization.DataRetrievingSimulationCompletedLog.TemplateParameters templateParameters) =>
              $"\"{ templateParameters.GatewayName }.{ templateParameters.TransactionName }\", " + 
                "the simulation of the data retrieving has complete.\n" +
              "The \"MockGatewayHelper\" class has finished the simulation of the data retrieving " +
                $"for the transaction \"{ templateParameters.GatewayName }.{ templateParameters.TransactionName }\"." +
                ( 
                  templateParameters.FormattedRequestParameters is not null ? 
                      $"\n\nRequest parameters:\n{ templateParameters.FormattedRequestParameters }" :
                      "" 
                ) +
                ( 
                   templateParameters.FormattedResponseData is not null ? 
                       $"\n\nRequest data:\n{ templateParameters.FormattedResponseData }" :
                       "" 
                );

  public Func<MockGatewayHelper.ILocalization.DataSubmittingSimulationCompletedLog.TemplateParameters, string> 
      GenerateDataSubmittingSimulationCompletedLog =>
          (MockGatewayHelper.ILocalization.DataSubmittingSimulationCompletedLog.TemplateParameters templateParameters) =>
              $"\"{ templateParameters.GatewayName }.{ templateParameters.TransactionName }\", " + 
                "the simulation of the data submitting has complete.\n" +
              "The \"MockGatewayHelper\" class has finished the simulation of the data submitting " +
                $"for the transaction \"{ templateParameters.GatewayName }.{ templateParameters.TransactionName }\"." +
                ( 
                  templateParameters.FormattedRequestData is not null ? 
                      $"\n\nRequest data:\n{ templateParameters.FormattedRequestData }" : 
                      "" 
                ) +
                ( 
                  templateParameters.FormattedResponseData is not null ? 
                    $"\n\nRequest data:\n{ templateParameters.FormattedResponseData }" :
                    "" 
                );
  
}