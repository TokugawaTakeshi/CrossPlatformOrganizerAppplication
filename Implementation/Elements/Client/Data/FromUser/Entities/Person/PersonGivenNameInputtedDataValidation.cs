using CommonSolution.Entities;
using Person = CommonSolution.Entities.Person;

using FrontEndFramework.InputtedValueValidation;
using FrontEndFramework.InputtedValueValidation.PreMadeRules;


namespace Client.Data.FromUser.Entities.Person;


internal class PersonGivenNameInputtedDataValidation : InputtedValueValidation
{
  
  internal PersonGivenNameInputtedDataValidation(
    bool? isInputRequired  = null,
    string? requiredValueIsMissingValidationErrorMessage = null
  ) : base(
    hasValueBeenOmitted: rawValue => String.IsNullOrEmpty(rawValue as string),
    isInputRequired: isInputRequired ?? CommonSolution.Entities.Person.FamilyName.IS_REQUIRED, 
    requiredInputIsMissingValidationErrorMessage: requiredValueIsMissingValidationErrorMessage,
    staticRules: new IRule[]
    {
      new MinimalCharactersCountInputtedValueValidationRule
      {
        MinimaCharactersCount = CommonSolution.Entities.Person.FamilyName.MINIMAL_CHARACTERS_COUNT,
        ErrorMessage = $"下の名前は最少{ CommonSolution.Entities.Person.FamilyName.MINIMAL_CHARACTERS_COUNT }を指定して下さい。",
        MustFinishValidationIfValueIsInvalid = true
      }
    }
  ) {}
  
}