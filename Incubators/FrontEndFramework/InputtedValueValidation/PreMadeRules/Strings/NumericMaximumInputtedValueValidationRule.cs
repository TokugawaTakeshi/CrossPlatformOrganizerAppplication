﻿namespace FrontEndFramework.InputtedValueValidation.PreMadeRules.Strings;


public class NumericMaximumInputtedValueValidationRule : YamatoDaiwa.Frontend.Components.Controls.Validation.InputtedValueValidation.IRule
{
  
  public interface ILocalization
  {

    public Func<ErrorMessage.TemplateVariables, string> ErrorMessageBuilder { get; }

    static class ErrorMessage
    {

      public struct TemplateVariables
      {
        public uint MaximalValue { get; init; }
        public string RawValue { get; init; }
      }

    }

  }
  
  public static ILocalization Localization = new NumericMaximumInputtedValueValidationRuleEnglishLocalization();
  
  
  public bool MustFinishValidationIfValueIsInvalid { get; init; }

  public uint MaximalValue { get; init; }
  public Func<ILocalization.ErrorMessage.TemplateVariables, string>? ErrorMessageBuilder { get; init; }
  public string? ErrorMessage { get; init; }
  
  
  public YamatoDaiwa.Frontend.Components.Controls.Validation.InputtedValueValidation.IRule.CheckingResult Check(object rawValue) =>
      new()
      {
        ErrorMessage = rawValue is uint uintValue && uintValue <= this.MaximalValue ? 
          null : 
          this.buildErrorMessage(
            new ILocalization.ErrorMessage.TemplateVariables
              {
                RawValue = rawValue.ToString() ?? "null", MaximalValue = this.MaximalValue
              }
          )
      };
  
  private string buildErrorMessage(ILocalization.ErrorMessage.TemplateVariables templateVariables)
  {

    if (this.ErrorMessageBuilder is not null)
    {
      return this.ErrorMessageBuilder(templateVariables);
    }


    return this.ErrorMessage ?? 
        NumericMaximumInputtedValueValidationRule.Localization.ErrorMessageBuilder(templateVariables);
    
  }
  
}