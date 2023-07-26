using FrontEndFramework.InputtedValueValidation;
using FrontEndFramework.InputtedValueValidation.PreMadeRules;


namespace Client.Data.FromUser.Entities.Person;


internal class PersonGivenNameInputtedDataValidation : InputtedValueValidation
{
  
  internal PersonGivenNameInputtedDataValidation(
    bool? isInputRequired = CommonSolution.Entities.Person.GivenName.IS_REQUIRED,
    string? requiredValueIsMissingValidationErrorMessage = "下の名前は必須ですから、お手数ですが、入力して下さい。"
  ) : base(
    hasValueBeenOmitted: rawValue => String.IsNullOrEmpty(rawValue as string),
    isInputRequired, 
    requiredInputIsMissingValidationErrorMessage: requiredValueIsMissingValidationErrorMessage,
    staticRules: new IRule[]
    {
      new MinimalCharactersCountInputtedValueValidationRule
      {
        MinimalCharactersCount = CommonSolution.Entities.Person.GivenName.MINIMAL_CHARACTERS_COUNT,
        ErrorMessage = $"下の名前は最少{ CommonSolution.Entities.Person.GivenName.MINIMAL_CHARACTERS_COUNT }を指定して下さい。",
        MustFinishValidationIfValueIsInvalid = true
      },
      new MaximalCharactersCountInputtedValueValidationRule
      {
        MaximalCharactersCount = CommonSolution.Entities.Person.GivenName.MAXIMAL_CHARACTERS_COUNT,
        ErrorMessage = $"下の名前は最大{ CommonSolution.Entities.Person.GivenName.MAXIMAL_CHARACTERS_COUNT }を指定して下さい。"
      }
    }
  ) {}
  
}