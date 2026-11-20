using ClientAndFrontServer;
using YamatoDaiwa.Frontend.GUI_Components.Snackbar;

namespace Client.Utils;


internal static class DataExchange
{
  
  internal static void handleDataSubmittingException(
    Exception caughtException,
    string genericLocalizationErrorMessage
  )
  {

    if (caughtException is ClientAndFrontServerTransactionSpecificException transactionSpecificException)
    {
      
      _ = Snackbar.displayForAWhile(
        message: transactionSpecificException.publicLocalizedErrorMessage,
        decorativeVariation: Snackbar.StandardDecorativeVariations.error
      );
      
      return;
      
    }
    
    
    _ = Snackbar.displayForAWhile(
      message: genericLocalizationErrorMessage,
      decorativeVariation: Snackbar.StandardDecorativeVariations.error
    );
    
  }
  
}
