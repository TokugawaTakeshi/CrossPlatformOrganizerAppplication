using FrontEndFramework.InputtedValueValidation;
using FrontEndFramework.InputtedValueValidation.PreMadeRules.Strings;


namespace Client.Data.FromUser.Entities.Task;


internal class TaskDescriptionInputtedDataValidation : InputtedValueValidation
{
  
  internal TaskDescriptionInputtedDataValidation(
    bool? isInputRequired = CommonSolution.Entities.Task.Description.IS_REQUIRED,
    string? requiredValueIsMissingValidationErrorMessage = "課題の詳細は必須となります。お手数ですが、入力してください。"
  ) : base(
    hasValueBeenOmitted: rawValue => String.IsNullOrEmpty(rawValue as string),
    isInputRequired: isInputRequired,
    requiredInputIsMissingValidationErrorMessage: requiredValueIsMissingValidationErrorMessage,
    staticRules: new IRule[] 
    {
      new MinimalCharactersCountInputtedValueValidationRule
      {
        MinimalCharactersCount = CommonSolution.Entities.Person.FamilyNameSpell.MINIMAL_CHARACTERS_COUNT,
        ErrorMessage = $"課題の詳細は最少{ CommonSolution.Entities.Person.FamilyNameSpell.MINIMAL_CHARACTERS_COUNT }を指定して下さい。",
        MustFinishValidationIfValueIsInvalid = true
      },
      new MaximalCharactersCountInputtedValueValidationRule
      {
        MaximalCharactersCount = CommonSolution.Entities.Person.FamilyNameSpell.MAXIMAL_CHARACTERS_COUNT,
        ErrorMessage = $"課題の詳細は最大{ CommonSolution.Entities.Person.FamilyNameSpell.MAXIMAL_CHARACTERS_COUNT }を指定して下さい。"
      }
    }
  ) {}
  
}