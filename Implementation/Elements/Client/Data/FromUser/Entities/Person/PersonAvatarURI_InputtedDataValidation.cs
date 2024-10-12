using YamatoDaiwa.Frontend.GUI_Components.Controls.Validation;


namespace Client.Data.FromUser.Entities.Person;


internal class PersonAvatarURI_InputtedDataValidation : InputtedValueValidation
{
  
  internal PersonAvatarURI_InputtedDataValidation(
    bool? isInputRequired = CommonSolution.Entities.Person.EmailAddress.IS_REQUIRED, 
    string? requiredInputIsMissingValidationErrorMessage = "アバターは必須となります。画像を選択して下さい。"
  ): base(
    isValueOfSupportedType: (object? rawValue) => rawValue is string,
    hasValueBeenOmitted: rawValue => String.IsNullOrEmpty(rawValue as string),
    isInputRequired,
    requiredInputIsMissingValidationErrorMessage: requiredInputIsMissingValidationErrorMessage
  ) {}
  
}