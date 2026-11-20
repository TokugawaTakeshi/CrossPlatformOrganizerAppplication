namespace ClientAndFrontServer.Transactions.AccessControl;


public record AccessControlTransactionsEnglishLocalization() : AccessControlTransactions.Localization(
  
  signingIn: new AccessControlTransactions.Localization.SigningIn(
        
    specificErrors: new AccessControlTransactions.Localization.SigningIn.SpecificErrors(
              
      invalidCombinationOfEmailAndPassword: 
          "The inputted email and password does not match. " +
          "Either user with inputted email not exist, or password is wrong."
              
    )
  
  )

);