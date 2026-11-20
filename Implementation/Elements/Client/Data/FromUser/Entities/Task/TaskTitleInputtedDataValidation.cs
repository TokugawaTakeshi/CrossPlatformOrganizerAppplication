using YamatoDaiwa.Frontend.GUI_Components.Controls.Validation;
using YamatoDaiwa.Frontend.GUI_Components.Controls.Validation.PreMadeRules.Strings;


namespace Client.Data.FromUser.Entities.Task;


internal class TaskTitleInputtedDataValidation : InputtedValueValidation
{

  internal TaskTitleInputtedDataValidation(
    bool? isInputRequired = CommonSolution.Entities.Task.Task.Title.IS_REQUIRED,
    string? requiredInputIsMissingValidationErrorMessage = "課題の見出しは必須となります。お手数ですが、入力して下さい。"
  ) : base(
    isValueOfSupportedType: (object? rawValue) => rawValue is string,
    hasValueBeenOmitted: rawValue => String.IsNullOrEmpty(rawValue as string),
    isInputRequired,
    requiredInputIsMissingValidationErrorMessage: requiredInputIsMissingValidationErrorMessage,
    staticRules:
    [
      new MinimalCharactersCountInputtedValueValidationRule
      {
        MinimalCharactersCount = CommonSolution.Entities.Task.Task.Title.MINIMAL_CHARACTERS_COUNT,
        ErrorMessage = $"課題の見出しは最少{ CommonSolution.Entities.Task.Task.Title.MINIMAL_CHARACTERS_COUNT }を指定して下さい。",
        MustFinishValidationIfValueIsInvalid = true
      },
      new MaximalCharactersCountInputtedValueValidationRule
      {
        MaximalCharactersCount = CommonSolution.Entities.Task.Task.Title.MAXIMAL_CHARACTERS_COUNT,
        ErrorMessage = $"課題の見出しは最大{ CommonSolution.Entities.Task.Task.Title.MAXIMAL_CHARACTERS_COUNT }を指定して下さい。"
      }
    ]
  ) {}
  
}