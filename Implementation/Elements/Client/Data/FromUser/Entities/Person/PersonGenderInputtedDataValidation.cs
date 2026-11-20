using CommonSolution.Fundamentals;
using YamatoDaiwa.Frontend.GUI_Components.Controls.Validation;


namespace Client.Data.FromUser.Entities.Person;


internal class PersonGenderInputtedDataValidation : InputtedValueValidation
{
  
  internal PersonGenderInputtedDataValidation(
    bool? isInputRequired = CommonSolution.Entities.Person.Gender.IS_REQUIRED,
    string? requiredInputIsMissingValidationErrorMessage = "性別は必須ですから、お手数ですが、指定して下さい。"
  ) : base(
    isValueOfSupportedType: (object? rawValue) => rawValue is Genders,
    hasValueBeenOmitted: rawValue => rawValue is null,
    isInputRequired, 
    requiredInputIsMissingValidationErrorMessage: requiredInputIsMissingValidationErrorMessage
  ) {}
  
}