namespace ClientAndFrontServer.Transactions.AccessControl;


public record AccessControlTransactionsJapaneseLocalization() : AccessControlTransactions.Localization(
  
  signingIn: new AccessControlTransactions.Localization.SigningIn(
    
    specificErrors: new AccessControlTransactions.Localization.SigningIn.SpecificErrors(
      
      invalidCombinationOfEmailAndPassword: 
          "入力されたメールアドレスとパスワードの組み合わせが合っていません。" +
          "このメールのユーザーが登録されていませんか、パスワードが間違っています。"
      
    )
    
  )
  
);
