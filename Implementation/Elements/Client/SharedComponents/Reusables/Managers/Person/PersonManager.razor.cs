using System.Diagnostics;
using Client.Data.FromUser.Entities.Person;
using CommonSolution.Fundamentals;
using FrontEndFramework.Components.Controls.TextBox;
using FrontEndFramework.Components.Controls.RadioButtonsGroup;
using FrontEndFramework.InputtedValueValidation;
using ValidatableControl = FrontEndFramework.ValidatableControl;

using Microsoft.EntityFrameworkCore;

using Utils;


namespace Client.SharedComponents.Reusables.Managers.Person;


public partial class PersonManager : Microsoft.AspNetCore.Components.ComponentBase
{

  /* ━━━ Blazorコンポーネント引数 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter] 
  public CommonSolution.Entities.Person? targetPerson { get; set; }

  [Microsoft.AspNetCore.Components.Parameter] 
  public string? activationGuidance { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; }

  
  /* ━━━ ステート ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private bool isViewingMode = true;
  private bool isEditingMode => !this.isViewingMode;
  
  private readonly string ID = PersonManager.generateComponentID();
  private string HEADING_ID => $"{ this.ID }-HEADING";
  
  private TextBox familyNameTextBox = null!;
  private TextBox givenNameTextBox = null!;
  private TextBox familyNameSpellTextBox = null!;
  private TextBox givenNameSpellTextBox = null!;
  private RadioButtonsGroup genderRadioButtonsGroup = null!;
  private TextBox emailAddressTextBox = null!;
  private TextBox phoneNumberTextBox = null!;

  private readonly RadioButtonsGroup.SelectingOption[] genderRadioButtonsGroupSelectingOptions = {
    new()
    {
      label = "男性",
      key = Genders.Male.ToString()
    },
    new()
    {
      label = "女性",
      key = Genders.Female.ToString()
    }
  };
      
  
  private (
    ValidatableControl.Payload familyName, 
    ValidatableControl.Payload givenName, 
    ValidatableControl.Payload familyNameSpell, 
    ValidatableControl.Payload givenNameSpell,
    ValidatableControl.Payload gender,
    ValidatableControl.Payload emailAddress, 
    ValidatableControl.Payload phoneNumber
  ) controlsPayload;
  
  
  /* ━━━ コンストラクタ ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public PersonManager()
  {
    this.controlsPayload = (
      familyName: new ValidatableControl.Payload(
        initialValue: "", 
        validation: new PersonFamilyNameInputtedDataValidation(),
        componentInstanceAccessor: () => this.familyNameTextBox
      ),
      givenName: new ValidatableControl.Payload(
        initialValue: "", 
        validation: new PersonGivenNameInputtedDataValidation(),
        componentInstanceAccessor: () => this.givenNameTextBox
      ),
      familyNameSpell: new ValidatableControl.Payload(
        initialValue: "", 
        validation: new PersonFamilyNameSpellInputtedDataValidation(),
        componentInstanceAccessor: () => this.familyNameSpellTextBox
      ),
      givenNameSpell: new ValidatableControl.Payload(
        initialValue: "", 
        validation: new PersonGivenNameSpellInputtedDataValidation(),
        componentInstanceAccessor: () => this.givenNameSpellTextBox
      ),
      gender: new ValidatableControl.Payload(
        initialValue: "",
        validation: new PersonGenderInputtedDataValidation(),
        componentInstanceAccessor: () => this.genderRadioButtonsGroup
      ),
      emailAddress: new ValidatableControl.Payload(
        initialValue: "",
        validation: new PersonEmailInputtedDataValidation(),
        componentInstanceAccessor: () => this.emailAddressTextBox
      ),
      phoneNumber: new ValidatableControl.Payload(
        initialValue: "",
        validation: new PersonPhoneNumberInputtedDataValidation(),
        componentInstanceAccessor: () => this.phoneNumberTextBox
      )
    );
  }

  
  /* ━━━ 行動処理 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private void beginPersonEditing()
  {

    if (this.targetPerson is null)
    {
      throw new Exception("「beginPersonEditing」メソッドは呼び出されたが、「targetPerson」は「null」のまま。");
    }

    
    this.controlsPayload.familyName.Value = this.targetPerson.familyName;
    this.controlsPayload.givenName.Value = this.targetPerson.givenName ?? "";
    this.controlsPayload.familyNameSpell.Value = this.targetPerson.familyNameSpell ?? "";
    this.controlsPayload.givenNameSpell.Value = this.targetPerson.givenNameSpell ?? "";
    this.controlsPayload.emailAddress.Value = this.targetPerson.emailAddress ?? "";
    this.controlsPayload.phoneNumber.Value = this.targetPerson.phoneNumber__digitsOnly ?? "";
    
    this.isViewingMode = false;
    
  }
  
  private void displayPersonDeletingConfirmationDialog()
  {
    // TODO
  }
  
  private void updatePersonIfInputtedDataIsValid()
  {

    if (ValidatableControlsGroup.HasInvalidInputs(this.controlsPayload))
    {
      ValidatableControlsGroup.PointOutValidationErrors(this.controlsPayload);
      return;
    }


    if (this.targetPerson is null)
    {
      // TODO OnNewPersonHasBeenAdded
      return;
    }
    
    this.targetPerson.familyName = this.controlsPayload.familyName.GetExpectedToBeValidValue<string>();
    this.targetPerson.givenName = this.controlsPayload.givenName.GetExpectedToBeValidValue<string>();
    this.targetPerson.familyNameSpell = this.controlsPayload.familyNameSpell.GetExpectedToBeValidValue<string>();
    this.targetPerson.givenNameSpell = this.controlsPayload.givenNameSpell.GetExpectedToBeValidValue<string>();
    this.targetPerson.emailAddress = this.controlsPayload.emailAddress.GetExpectedToBeValidValue<string>();
    this.targetPerson.phoneNumber__digitsOnly = this.controlsPayload.phoneNumber.GetExpectedToBeValidValue<string>().
        RemoveAllSpecifiedCharacters(new []{ '-' });
    
    // TODO そのままでtargetPersonを更新しても良いと思わん。

  }
  
  private void utilizePersonEditing()
  {
    
    this.isViewingMode = true;
    
    this.controlsPayload.familyName.Value = "";
    this.controlsPayload.givenName.Value = "";
    this.controlsPayload.familyNameSpell.Value = "";
    this.controlsPayload.givenNameSpell.Value = "";
    this.controlsPayload.emailAddress.Value = "";

  }
  
  
  /* ─── 新規追加・編集 ──────────────────────────────────────────────────────────────────────────────────────────────── */
  // TODO


  /* ━━━ ルーチン ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── ID生成 ────────────────────────────────────────────────────────────────────────────────────────────────────── */
  private static uint counterForComponentID_Generating = 0;

  private static string generateComponentID()
  {
    PersonManager.counterForComponentID_Generating++;
    return $"PERSON_MANAGER-{ PersonManager.counterForComponentID_Generating }";
  }
  
}