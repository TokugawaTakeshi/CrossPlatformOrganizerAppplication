using Client.Data.FromUser.Entities.Person;

using Client.SharedComponents.Managers.Person.Localization;

using YamatoDaiwa.Frontend.Components.Controls.Validation;
using FrontEndFramework.InputtedValueValidation;

using FrontEndFramework.Components.Controls.TextBox;
using FrontEndFramework.Components.Controls.FilesUploader;
using FrontEndFramework.Components.Controls.RadioButtonsGroup;
using FrontEndFramework.Components.ModalDialogs.Confirmation;

using CommonSolution.Fundamentals;

using System.Globalization;
using Client.Resources.Localizations;
using YamatoDaiwa.CSharpExtensions;
using Utils;


namespace Client.SharedComponents.Managers.Person;


public partial class PersonManager : Microsoft.AspNetCore.Components.ComponentBase
{

  /* ━━━ Component parameters ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter] 
  public CommonSolution.Entities.Person? targetPerson { get; set; }

  [Microsoft.AspNetCore.Components.Parameter]
  [Microsoft.AspNetCore.Components.EditorRequired]
  public required Microsoft.AspNetCore.Components.EventCallback<
    CommonSolution.Gateways.PersonGateway.Adding.RequestData
  > onInputtingDataOfNewPersonCompleteEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  [Microsoft.AspNetCore.Components.EditorRequired]
  public required Microsoft.AspNetCore.Components.EventCallback<
    CommonSolution.Gateways.PersonGateway.Updating.RequestData
  > onExistingPersonEditingCompleteEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  [Microsoft.AspNetCore.Components.EditorRequired]
  public required Microsoft.AspNetCore.Components.EventCallback<
    CommonSolution.Entities.Person
  > onDeletePersonEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  [Microsoft.AspNetCore.Components.EditorRequired]
  public required string activationGuidance { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public string? rootElementModifierCSS_Class { get; set; }

  
  /* ━━━ Fields ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private (
    FrontEndFramework.ValidatableControl.Payload familyName, 
    FrontEndFramework.ValidatableControl.Payload givenName, 
    FrontEndFramework.ValidatableControl.Payload familyNameSpell, 
    FrontEndFramework.ValidatableControl.Payload givenNameSpell,
    FrontEndFramework.ValidatableControl.Payload gender,
    FrontEndFramework.ValidatableControl.Payload emailAddress, 
    FrontEndFramework.ValidatableControl.Payload phoneNumber
  ) personControlsPayload;
  
  private TextBox familyNameTextBox = null!;
  private TextBox givenNameTextBox = null!;
  private TextBox familyNameSpellTextBox = null!;
  private TextBox givenNameSpellTextBox = null!;
  private RadioButtonsGroup genderRadioButtonsGroup = null!;
  private TextBox emailAddressTextBox = null!;
  private TextBox phoneNumberTextBox = null!;

  private readonly RadioButtonsGroup.SelectingOption[] genderRadioButtonsGroupSelectingOptions;
  
  private TextBox.ValidityHighlightingActivationModes validityHighlightingActivationMode => 
      this.targetPerson is null ?
        TextBox.ValidityHighlightingActivationModes.onFocusOut :
        TextBox.ValidityHighlightingActivationModes.immediate;
  
  private bool isViewingMode = true;
  private bool isEditingMode => !this.isViewingMode;
  
  private readonly string ID = PersonManager.generateComponentID();
  private string HEADING_ID;
  
  private readonly PersonManagerLocalization localization = 
      ClientConfigurationRepresentative.MustForceDefaultLocalization ?
          new PersonManagerEnglishLocalization() :
          CultureInfo.CurrentCulture.Name switch
          {
            SupportedCultures.JAPANESE => new PersonManagerJapaneseLocalization(),
            _ => new PersonManagerEnglishLocalization()
          };
  
  private readonly SharedStaticStrings sharedStaticStrings = 
      ClientConfigurationRepresentative.MustForceDefaultLocalization ?
          SharedStaticEnglishStrings.SingleInstance : 
          CultureInfo.CurrentCulture.Name switch
          {
            SupportedCultures.JAPANESE => SharedStaticJapaneseStrings.SingleInstance,
            _ => SharedStaticEnglishStrings.SingleInstance
          };
  
  
  /* ━━━ Constructor ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public PersonManager()
  {
    
    this.HEADING_ID = $"{ this.ID }-HEADING";
    
    this.personControlsPayload = (
      familyName: new FrontEndFramework.ValidatableControl.Payload(
        initialValue: "", 
        validation: new PersonFamilyNameInputtedDataValidation(),
        componentInstanceAccessor: () => this.familyNameTextBox
      ),
      givenName: new FrontEndFramework.ValidatableControl.Payload(
        initialValue: "", 
        validation: new PersonGivenNameInputtedDataValidation(),
        componentInstanceAccessor: () => this.givenNameTextBox
      ),
      familyNameSpell: new FrontEndFramework.ValidatableControl.Payload(
        initialValue: "", 
        validation: new PersonFamilyNameSpellInputtedDataValidation(),
        componentInstanceAccessor: () => this.familyNameSpellTextBox
      ),
      givenNameSpell: new FrontEndFramework.ValidatableControl.Payload(
        initialValue: "", 
        validation: new PersonGivenNameSpellInputtedDataValidation(),
        componentInstanceAccessor: () => this.givenNameSpellTextBox
      ),
      gender: new FrontEndFramework.ValidatableControl.Payload(
        initialValue: "",
        validation: new PersonGenderInputtedDataValidation(),
        componentInstanceAccessor: () => this.genderRadioButtonsGroup
      ),
      emailAddress: new FrontEndFramework.ValidatableControl.Payload(
        initialValue: "",
        validation: new PersonEmailInputtedDataValidation(),
        componentInstanceAccessor: () => this.emailAddressTextBox
      ),
      phoneNumber: new FrontEndFramework.ValidatableControl.Payload(
        initialValue: "",
        validation: new PersonPhoneNumberInputtedDataValidation(),
        componentInstanceAccessor: () => this.phoneNumberTextBox
      )
    );
    
    this.genderRadioButtonsGroupSelectingOptions =
    [
      new RadioButtonsGroup.SelectingOption
      {
        label = this.localization.controls.gender.optionsLabels.male,
        key = Genders.Male.ToString()
      },
      new RadioButtonsGroup.SelectingOption()
      {
        label = this.localization.controls.gender.optionsLabels.female,
        key = Genders.Female.ToString()
      }
    ];
    
  }
  
  /* ━━━ Public methods ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public void utilizePersonEditing()
  {
    
    this.isViewingMode = true;
    
    this.personControlsPayload.familyName.SetValue("");
    this.personControlsPayload.givenName.SetValue("");
    this.personControlsPayload.familyNameSpell.SetValue("");
    this.personControlsPayload.givenNameSpell.SetValue("");
    this.personControlsPayload.emailAddress.SetValue("");
    this.personControlsPayload.phoneNumber.SetValue("");

  }

  
  /* ━━━ Actions handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public void beginInputNewPersonData()
  {
    this.isViewingMode = false;
  }
  
  private void beginPersonEditing()
  {

    if (this.targetPerson is null)
    {
      throw new Exception("\"beginPersonEditing\" has been called while \"targetPerson\" is still \"null\".");
    }

    
    this.personControlsPayload.familyName.SetValue(this.targetPerson.familyName);
    this.personControlsPayload.givenName.SetValue(this.targetPerson.givenName ?? "");
    this.personControlsPayload.familyNameSpell.SetValue(this.targetPerson.familyNameSpell ?? "");
    this.personControlsPayload.givenNameSpell.SetValue(this.targetPerson.givenNameSpell ?? "");
    this.personControlsPayload.emailAddress.SetValue(this.targetPerson.emailAddress ?? "");
    this.personControlsPayload.phoneNumber.SetValue(this.targetPerson.phoneNumber__digitsOnly ?? "");
    
    this.isViewingMode = false;
    
  }
  
  private void displayPersonDeletingConfirmationDialog()
  {
    ConfirmationModalDialogService.displayModalDialog(
      new ConfirmationModalDialog.Options()
      {
        title = this.localization.personDeletingConfirmationModalDialog.title,
        question = this.localization.personDeletingConfirmationModalDialog.question,
        onConfirmationButtonClickedEventHandler = this.deletePerson
      }  
    );
  }

  private async void onClickPersonDataSavingButton()
  {

    if (ValidatableControlsGroup.HasInvalidInputs(this.personControlsPayload))
    {
      ValidatableControlsGroup.PointOutValidationErrors(this.personControlsPayload);
      return;
    }


    if (this.targetPerson is null)
    {
      
      await this.onInputtingDataOfNewPersonCompleteEventHandler.InvokeAsync(
        new CommonSolution.Gateways.PersonGateway.Adding.RequestData
        {
          FamilyName = this.personControlsPayload.familyName.GetExpectedToBeValidValue<string>(),
          GivenName = this.personControlsPayload.givenName.GetExpectedToBeValidValue<string>(),
          FamilyNameSpell = this.personControlsPayload.familyNameSpell.GetExpectedToBeValidValue<string>(),
          GivenNameSpell = this.personControlsPayload.givenNameSpell.GetExpectedToBeValidValue<string>(),
          Gender = this.personControlsPayload.gender.GetExpectedToBeValidValue<Genders>(),
          EmailAddress = this.personControlsPayload.emailAddress.GetExpectedToBeValidValue<string>(),
          PhoneNumber__DigitsOnly = this.personControlsPayload.phoneNumber.GetExpectedToBeValidValue<string>()
        }
      );
      
      return;
      
    }


    await this.onExistingPersonEditingCompleteEventHandler.InvokeAsync(
      new CommonSolution.Gateways.PersonGateway.Updating.RequestData
      {
        ID = this.targetPerson.ID,
        FamilyName = this.personControlsPayload.familyName.GetExpectedToBeValidValue<string>(),
        GivenName = this.personControlsPayload.givenName.GetExpectedToBeValidValue<string>(),
        FamilyNameSpell = this.personControlsPayload.familyNameSpell.GetExpectedToBeValidValue<string>(),
        GivenNameSpell = this.personControlsPayload.givenNameSpell.GetExpectedToBeValidValue<string>(),
        Gender = this.personControlsPayload.gender.GetExpectedToBeValidValue<Genders>(),
        EmailAddress = this.personControlsPayload.emailAddress.GetExpectedToBeValidValue<string>(),
        PhoneNumber__DigitsOnly = this.personControlsPayload.phoneNumber.GetExpectedToBeValidValue<string>()
      }
    );
    
  }

  private async void deletePerson()
  {

    if (this.targetPerson is null)
    {
      throw new Exception("\"deletePerson\" method has been called while \"targetPerson\" is still \"null\".");
    }

    
    await this.onDeletePersonEventHandler.InvokeAsync(this.targetPerson);

  }
  

  /* ━━━ Routines ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── Generating of ID ─────────────────────────────────────────────────────────────────────────────────────────── */
  private static uint counterForComponentID_Generating = 0;

  private static string generateComponentID()
  {
    PersonManager.counterForComponentID_Generating++;
    return $"PERSON_MANAGER-{ PersonManager.counterForComponentID_Generating }";
  }
  
}