using YamatoDaiwa.Frontend.GUI_Components.Controls.Validation.PreMadeValidations;


namespace Client.Data.FromUser.Entities.Person;


internal class PersonEmailInputtedDataValidation : EmailAddressInputtedValueValidation
{
  
  internal PersonEmailInputtedDataValidation(
    bool? isInputRequired = CommonSolution.Entities.Person.EmailAddress.IS_REQUIRED 
  ): base(
    isInputRequired
  ) {}
  
}