using Client.Resources.Localizations;


namespace Client.SharedComponents.Managers.Person.Localization;


internal abstract record PersonManagerLocalization
{
  
  internal abstract string heading { get; }
 
  
  internal record Buttons
  {
    internal required SharedStaticStrings.ButtonWithVisibleLabel personEditing { get; init; }
    internal required SharedStaticStrings.ButtonWithVisibleLabel personDeleting { get; init; }
    internal required SharedStaticStrings.ButtonWithVisibleLabel personSaving { get; init; }
    internal required SharedStaticStrings.ButtonWithVisibleLabel terminatingOfEditing { get; init; }
  }
  
  internal abstract Buttons buttons { get; init; }
  
  
  internal record MetadataKeys
  {
    internal required string name { get; init; }
    internal required string nameSpell { get; init; }
    internal required string gender { get; init; }
    internal required string birthDate { get; init; }
    internal required string emailAddress { get; init; }
    internal required string phoneNumber { get; init; }
  }
  
  internal abstract MetadataKeys metadataKeys { get; }
  
  internal record Controls
  {
    
    internal required SharedStaticStrings.ControlWithLabelAndGuidance familyName { get; init; }
    internal required SharedStaticStrings.ControlWithLabelAndGuidance givenName { get; init; }
    internal required SharedStaticStrings.ControlWithLabelAndGuidance familyNameSpell { get; init; }
    internal required SharedStaticStrings.ControlWithLabelAndGuidance givenNameSpell { get; init; }
    
    internal record RadioButton
    {
      internal required string label { get; init; }
      
      internal required OptionsLabels optionsLabels { get; init; }

      internal record OptionsLabels
      {
        internal required string male { get; init; }
        internal required string female { get; init; }
      }
      
    }
    
    internal required RadioButton gender { get; init; }
    
    internal required string emailAddress { get; init; }
    internal required string phoneNumber { get; init; }
    
  }
  
  internal abstract Controls controls { get; }
  
  internal abstract SharedStaticStrings.ModalDialog personDeletingConfirmationModalDialog { get; init; }


}