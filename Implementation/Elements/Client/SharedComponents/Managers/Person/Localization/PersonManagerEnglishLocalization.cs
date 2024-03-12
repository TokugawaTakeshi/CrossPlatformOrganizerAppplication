using Client.Resources.Localizations;


namespace Client.SharedComponents.Managers.Person.Localization;


internal record PersonManagerEnglishLocalization : PersonManagerLocalization
{
 
  internal override string heading { get; } = "Person (Contact) Manager";
  
  internal override Buttons buttons { get; init; } = new()
  {
    personEditing = new SharedStaticStrings.ButtonWithVisibleLabel { label = "Edit Person"},
    personDeleting = new SharedStaticStrings.ButtonWithVisibleLabel { label = "Delete Person"},
    personSaving = new SharedStaticStrings.ButtonWithVisibleLabel { label = "Save Person"},
    terminatingOfEditing = new SharedStaticStrings.ButtonWithVisibleLabel { label = "Cancel Editing"}
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

  internal override SharedStaticStrings.ModalDialog personDeletingConfirmationModalDialog { get; init; } = new()
  {
    title = "Deleting Confirmation",
    question = "Are you sure about deleting of this task?"
  };
  
  internal override Controls controls { get; } = new()
  {
    familyName = new SharedStaticStrings.ControlWithLabelAndGuidance
    {
      label = "Family Name",
      guidance = $"Please input **{ CommonSolution.Entities.Person.FamilyName.MINIMAL_CHARACTERS_COUNT } - " + 
          $"{ CommonSolution.Entities.Person.FamilyName.MAXIMAL_CHARACTERS_COUNT }** characters." 
          
    },
    givenName = new SharedStaticStrings.ControlWithLabelAndGuidance
    {
      label = "Given Name",
      guidance = $"Please input **{ CommonSolution.Entities.Person.GivenName.MINIMAL_CHARACTERS_COUNT } - " + 
          $"{ CommonSolution.Entities.Person.GivenName.MAXIMAL_CHARACTERS_COUNT }** characters." 
    },
    familyNameSpell = new SharedStaticStrings.ControlWithLabelAndGuidance
    {
      label = "Family Name Spell",
      guidance = $"Please input **{ CommonSolution.Entities.Person.FamilyNameSpell.MINIMAL_CHARACTERS_COUNT } - " + 
          $"{ CommonSolution.Entities.Person.FamilyNameSpell.MAXIMAL_CHARACTERS_COUNT }** characters." 
          
    },
    givenNameSpell = new SharedStaticStrings.ControlWithLabelAndGuidance
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