using YamatoDaiwa.Frontend.GUI_Components.Controls.Validation;
using YamatoDaiwa.Frontend.GUI_Components.Controls.Validation.PreMadeRules.Strings;


namespace Client.Data.FromUser.Entities.Person;


internal class PersonFamilyNameInputtedDataValidation : InputtedValueValidation
{
  
  internal PersonFamilyNameInputtedDataValidation(
    bool? isInputRequired = CommonSolution.Entities.Person.FamilyName.IS_REQUIRED,
    string? requiredInputIsMissingValidationErrorMessage = "上の名前は必須ですから、お手数ですが、入力して下さい。"
  ) : base(
    isValueOfSupportedType: (object? rawValue) => rawValue is string,
    hasValueBeenOmitted: rawValue => String.IsNullOrEmpty(rawValue as string),
    isInputRequired,
    requiredInputIsMissingValidationErrorMessage: requiredInputIsMissingValidationErrorMessage,
    staticRules:
    [
      new MinimalCharactersCountInputtedValueValidationRule
      {
        MinimalCharactersCount = CommonSolution.Entities.Person.FamilyName.MINIMAL_CHARACTERS_COUNT,
        ErrorMessage = $"上の名前は最少{ CommonSolution.Entities.Person.FamilyName.MINIMAL_CHARACTERS_COUNT }を指定して下さい。",
        MustFinishValidationIfValueIsInvalid = true
      }
    ]
  ) {}
  
}