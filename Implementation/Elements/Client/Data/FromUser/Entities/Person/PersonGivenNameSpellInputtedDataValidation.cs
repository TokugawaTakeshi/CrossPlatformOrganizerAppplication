using YamatoDaiwa.Frontend.GUI_Components.Controls.Validation;
using YamatoDaiwa.Frontend.GUI_Components.Controls.Validation.PreMadeRules.Strings;


namespace Client.Data.FromUser.Entities.Person;


internal class PersonGivenNameSpellInputtedDataValidation : InputtedValueValidation
{
  
  internal PersonGivenNameSpellInputtedDataValidation(
    bool? isInputRequired = CommonSolution.Entities.Person.GivenNameSpell.IS_REQUIRED,
    string? requiredValueIsMissingValidationErrorMessage = "下の名前の読み方は必須ですから、お手数ですが、入力して下さい。"
  ) : base(
    isValueOfSupportedType: (object? rawValue) => rawValue is string,
    hasValueBeenOmitted: rawValue => String.IsNullOrEmpty(rawValue as string),
    isInputRequired,
    requiredInputIsMissingValidationErrorMessage: requiredValueIsMissingValidationErrorMessage,
    staticRules:
    [
      new MinimalCharactersCountInputtedValueValidationRule
      {
        MinimalCharactersCount = CommonSolution.Entities.Person.GivenNameSpell.MINIMAL_CHARACTERS_COUNT,
        ErrorMessage = $"下の名前の読み方は最少{ CommonSolution.Entities.Person.GivenNameSpell.MINIMAL_CHARACTERS_COUNT }を指定して下さい。",
        MustFinishValidationIfValueIsInvalid = true
      }
    ]
  ) {}
  
}