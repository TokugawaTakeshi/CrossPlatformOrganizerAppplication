namespace FrontEndFramework.InputtedValueValidation.PreMadeRules.Strings;


public struct MinimalCharactersCountInputtedValueValidationRuleEnglishLocalization : 
    MinimalCharactersCountInputtedValueValidationRule.ILocalization
{
  
  public Func<
    MinimalCharactersCountInputtedValueValidationRule.ILocalization.ErrorMessage.TemplateVariables, string
  > ErrorMessageBuilder => 
      templateVariables =>
          "Not enough characters has been inputted. " +
          $"Please input at least { templateVariables.MinimalCharactersCount } characters.";

}