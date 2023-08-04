﻿using FrontEndFramework.InputtedValueValidation;
using FrontEndFramework.InputtedValueValidation.PreMadeRules.Strings;

namespace Client.Data.FromUser.Entities.Person;


public class PersonPhoneNumberInputtedDataValidation : InputtedValueValidation
{
  public PersonPhoneNumberInputtedDataValidation(
    bool? isInputRequired = CommonSolution.Entities.Person.PhoneNumber__DigitsOnly.IS_REQUIRED, 
    string? requiredInputIsMissingValidationErrorMessage = "電話番号は必須となります。お手数ですがメールアドレスを入力して下さい。"  
  ): base(
    hasValueBeenOmitted: rawValue => String.IsNullOrEmpty(rawValue as string),
    isInputRequired,
    requiredInputIsMissingValidationErrorMessage: requiredInputIsMissingValidationErrorMessage,
    staticRules: new IRule[]
    {
      new JapanesePhoneNumberInputtedValueValidationRule()
      {
        ErrorMessage = "入力された電話番号は日本電話番号ではない様です。お手数ですが、電話番号をご確認下さい。"
      }
    }
  ) {}
}