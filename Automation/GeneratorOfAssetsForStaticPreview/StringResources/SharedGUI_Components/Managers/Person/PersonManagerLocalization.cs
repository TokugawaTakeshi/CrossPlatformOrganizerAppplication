/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Managers.Person;


internal abstract record PersonManagerLocalization
{
  
  internal abstract string heading { get; }
 
  
  internal record Buttons
  {
    internal required CommonStringResources.ButtonWithVisibleLabel personEditing { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel personDeleting { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel personSaving { get; init; }
    internal required CommonStringResources.ButtonWithVisibleLabel terminatingOfEditing { get; init; }
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
    
    internal required CommonStringResources.ControlWithLabelAndGuidance familyName { get; init; }
    internal required CommonStringResources.ControlWithLabelAndGuidance givenName { get; init; }
    internal required CommonStringResources.ControlWithLabelAndGuidance familyNameSpell { get; init; }
    internal required CommonStringResources.ControlWithLabelAndGuidance givenNameSpell { get; init; }
    
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
  
  internal abstract CommonStringResources.ModalDialog personDeletingConfirmationModalDialog { get; init; }


}