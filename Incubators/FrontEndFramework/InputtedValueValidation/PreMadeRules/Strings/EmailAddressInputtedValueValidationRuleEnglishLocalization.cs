﻿namespace FrontEndFramework.InputtedValueValidation.PreMadeRules.Strings;


public class EmailAddressInputtedValueValidationRuleEnglishLocalization : 
    EmailAddressInputtedValueValidationRule.ILocalization
{

  public Func<
    EmailAddressInputtedValueValidationRule.ILocalization.ErrorMessage.TemplateVariables, string
  > ErrorMessageBuilder => 
    _ =>
        "The inputted email address is impossible. " +
        "It must the mistyping. " +
        "Please correct the correct email addres. ";

}