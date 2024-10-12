/* [ !!! ATTENTION !!! ] NO MANUAL EDITING!!!       */
/* This file is being GENERATED REPEATEDLY.         */
/* All manual changes COULD BE LOST AT ANY MOMENT.  */

using GeneratorOfAssetsForStaticPreview.StringResources.Common;

namespace GeneratorOfAssetsForStaticPreview.StringResources.SharedGUI_Components.Managers.Person;


internal record PersonManagerEnglishLocalization : PersonManagerLocalization
{
 
  internal override string heading { get; } = "Person (Contact) Manager";
  
  internal override Buttons buttons { get; init; } = new()
  {
    personEditing = new CommonStringResources.ButtonWithVisibleLabel { label = "Edit Person"},
    personDeleting = new CommonStringResources.ButtonWithVisibleLabel { label = "Delete Person"},
    personSaving = new CommonStringResources.ButtonWithVisibleLabel { label = "Save Person"},
    terminatingOfEditing = new CommonStringResources.ButtonWithVisibleLabel { label = "Cancel Editing"}
  };

  internal override MetadataKeys metadataKeys { get; } = new()
  {
    name = "Name",
    nameSpell = "Name Spell",
    gender = "Gender",
    birthDate = "Birth Date",
    emailAddress = "Email Address",
    phoneNumber = "Phone Number"
  };

  internal override CommonStringResources.ModalDialog personDeletingConfirmationModalDialog { get; init; } = new()
  {
    title = "Deleting Confirmation",
    question = "Are you sure about deleting of this task?"
  };
  
  internal override Controls controls { get; } = new()
  {
    familyName = new CommonStringResources.ControlWithLabelAndGuidance
    {
      label = "Family Name",
      guidance = $"Please input **{ CommonSolution.Entities.Person.FamilyName.MINIMAL_CHARACTERS_COUNT } - " + 
          $"{ CommonSolution.Entities.Person.FamilyName.MAXIMAL_CHARACTERS_COUNT }** characters." 
          
    },
    givenName = new CommonStringResources.ControlWithLabelAndGuidance
    {
      label = "Given Name",
      guidance = $"Please input **{ CommonSolution.Entities.Person.GivenName.MINIMAL_CHARACTERS_COUNT } - " + 
          $"{ CommonSolution.Entities.Person.GivenName.MAXIMAL_CHARACTERS_COUNT }** characters." 
    },
    familyNameSpell = new CommonStringResources.ControlWithLabelAndGuidance
    {
      label = "Family Name Spell",
      guidance = $"Please input **{ CommonSolution.Entities.Person.FamilyNameSpell.MINIMAL_CHARACTERS_COUNT } - " + 
          $"{ CommonSolution.Entities.Person.FamilyNameSpell.MAXIMAL_CHARACTERS_COUNT }** characters." 
          
    },
    givenNameSpell = new CommonStringResources.ControlWithLabelAndGuidance
    {
      label = "Given Name Spell",
      guidance = $"Please input **{ CommonSolution.Entities.Person.GivenNameSpell.MINIMAL_CHARACTERS_COUNT } - " + 
          $"{ CommonSolution.Entities.Person.GivenNameSpell.MAXIMAL_CHARACTERS_COUNT }** characters." 
    },
    gender = new Controls.RadioButton
    {
      label = "Gender",
      optionsLabels = new Controls.RadioButton.OptionsLabels
      {
        male = "male",
        female = "female"
      }
    },
    emailAddress = "Email Address",
    phoneNumber = "Phone Number"
  };

}