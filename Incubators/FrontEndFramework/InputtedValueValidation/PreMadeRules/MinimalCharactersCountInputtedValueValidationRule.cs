namespace FrontEndFramework.InputtedValueValidation.PreMadeRules;


public class MinimalCharactersCountInputtedValueValidationRule : InputtedValueValidation.IRule
{
  
  public interface ILocalization
  {

    public Func<ErrorMessage.TemplateVariables, string> ErrorMessageBuilder { get; }

    static class ErrorMessage
    {

      public struct TemplateVariables
      {
        public uint MinimalCharactersCount { get; init; }
        public string RawValue { get; init; }
      }

    }

  }

  public static ILocalization Localization = new MinimalCharactersCountInputtedValueValidationRuleEnglishLocalization();

  
  public bool MustFinishValidationIfValueIsInvalid { get; init; }

  public uint MinimaCharactersCount { get; init; }
  public Func<ILocalization.ErrorMessage.TemplateVariables, string>? ErrorMessageBuilder { get; init; }
  public string? ErrorMessage { get; init; }

  
  public InputtedValueValidation.IRule.CheckingResult Check(object rawValue)
  {

    return new InputtedValueValidation.IRule.CheckingResult
    {
      ErrorMessage = rawValue is String stringValue && stringValue.Length >= this.MinimaCharactersCount ? 
          null : 
          this.buildErrorMessage(new ILocalization.ErrorMessage.TemplateVariables()
          {
            RawValue = rawValue.ToString() ?? "null", MinimalCharactersCount = this.MinimaCharactersCount
          })
    };
  }


  private string buildErrorMessage(ILocalization.ErrorMessage.TemplateVariables templateVariables)
  {

    if (this.ErrorMessageBuilder is not null)
    {
      return this.ErrorMessageBuilder(templateVariables);
    }


    if (this.ErrorMessage is not null)
    {
      return this.ErrorMessage;
    }


    return MinimalCharactersCountInputtedValueValidationRule.Localization.ErrorMessageBuilder(templateVariables);

  }


}