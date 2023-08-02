using FrontEndFramework.InputtedValueValidation;
using FrontEndFramework.InputtedValueValidation.PreMadeRules.Strings;


namespace Client.Data.FromUser.Entities.Person;


internal class PersonFamilyNameSpellInputtedDataValidation : InputtedValueValidation
{
  
  internal PersonFamilyNameSpellInputtedDataValidation(
    bool? isInputRequired = CommonSolution.Entities.Person.FamilyNameSpell.IS_REQUIRED,
    string? requiredInputIsMissingValidationErrorMessage = "上の名前の読み方は必須ですから、お手数ですが、入力して下さい。"
  ) : base(
    hasValueBeenOmitted: rawValue => String.IsNullOrEmpty(rawValue as string),
    isInputRequired, 
    requiredInputIsMissingValidationErrorMessage: requiredInputIsMissingValidationErrorMessage,
    staticRules: new IRule[]
    {
      new MinimalCharactersCountInputtedValueValidationRule
      {
        MinimalCharactersCount = CommonSolution.Entities.Person.FamilyNameSpell.MINIMAL_CHARACTERS_COUNT,
        ErrorMessage = $"上の名前の読み方は最少{ CommonSolution.Entities.Person.FamilyNameSpell.MINIMAL_CHARACTERS_COUNT }を指定して下さい。",
        MustFinishValidationIfValueIsInvalid = true
      },
      new MaximalCharactersCountInputtedValueValidationRule
      {
        MaximalCharactersCount = CommonSolution.Entities.Person.FamilyNameSpell.MAXIMAL_CHARACTERS_COUNT,
        ErrorMessage = $"上の名前の読み方は最大{ CommonSolution.Entities.Person.FamilyNameSpell.MAXIMAL_CHARACTERS_COUNT }を指定して下さい。"
      }
    }
  ) {}
  
}