using CommonSolution.Fundamentals;

using Client.Data.FromUser.Entities.Person;

using FrontEndFramework.Components.Controls.FilesUploader;
using FrontEndFramework.Components.Controls.TextBox;
using FrontEndFramework.Components.Controls.RadioButtonsGroup;
using FrontEndFramework.InputtedValueValidation;

using ValidatableControl = FrontEndFramework.ValidatableControl;

using Microsoft.EntityFrameworkCore;

using YamatoDaiwaCS_Extensions;
using Utils;


namespace Client.SharedComponents.Managers.Person;


public partial class PersonManager : Microsoft.AspNetCore.Components.ComponentBase
{

  /* ━━━ Blazorコンポーネント引数 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter] 
  public CommonSolution.Entities.Person? targetPerson { get; set; }

  [Microsoft.AspNetCore.Components.Parameter] 
  public required string activationGuidance { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public string? rootElementModifierCSS_Class { get; set; }

  
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
  private FilesUploader avatarUploader = null!;
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
    ValidatableControl.Payload avatarURI,
    ValidatableControl.Payload emailAddress, 
    ValidatableControl.Payload phoneNumber
  ) personControlsPayload;
  
  
  /* ━━━ コンストラクタ ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public PersonManager()
  {
    this.personControlsPayload = (
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
      avatarURI: new ValidatableControl.Payload(
        initialValue: "",
        validation: new PersonAvatarURI_InputtedDataValidation(),
        componentInstanceAccessor: () => this.avatarUploader
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

  
  /* ━━━ 行動処理 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private void beginPersonEditing()
  {

    if (this.targetPerson is null)
    {
      throw new Exception("「beginPersonEditing」メソッドは呼び出されたが、「targetPerson」は「null」のまま。");
    }

    
    this.personControlsPayload.familyName.Value = this.targetPerson.familyName;
    this.personControlsPayload.givenName.Value = this.targetPerson.givenName ?? "";
    this.personControlsPayload.familyNameSpell.Value = this.targetPerson.familyNameSpell ?? "";
    this.personControlsPayload.givenNameSpell.Value = this.targetPerson.givenNameSpell ?? "";
    this.personControlsPayload.emailAddress.Value = this.targetPerson.emailAddress ?? "";
    this.personControlsPayload.phoneNumber.Value = this.targetPerson.phoneNumber__digitsOnly ?? "";
    
    this.isViewingMode = false;
    
  }
  
  private void displayPersonDeletingConfirmationDialog()
  {
    // TODO
  }

  
  /* ─── 新規追加・編集 ──────────────────────────────────────────────────────────────────────────────────────────────── */
  private void onClickPersonDataSavingButton()
  {

    if (ValidatableControlsGroup.HasInvalidInputs(this.personControlsPayload))
    {
      ValidatableControlsGroup.PointOutValidationErrors(this.personControlsPayload);
      return;
    }


    if (this.targetPerson is null)
    {
      // TODO OnNewPersonHasBeenAdded event
      return;
    }
    
    
    this.targetPerson.familyName = this.personControlsPayload.familyName.GetExpectedToBeValidValue<string>();
    this.targetPerson.givenName = this.personControlsPayload.givenName.GetExpectedToBeValidValue<string>();
    this.targetPerson.familyNameSpell = this.personControlsPayload.familyNameSpell.GetExpectedToBeValidValue<string>();
    this.targetPerson.givenNameSpell = this.personControlsPayload.givenNameSpell.GetExpectedToBeValidValue<string>();
    this.targetPerson.emailAddress = this.personControlsPayload.emailAddress.GetExpectedToBeValidValue<string>();
    this.targetPerson.phoneNumber__digitsOnly = this.personControlsPayload.phoneNumber.GetExpectedToBeValidValue<string>().
        RemoveAllSpecifiedCharacters(new []{ '-' });
    // TODO 其の他のフィルド
    // TODO そのままでtargetPersonを更新してもとは限らん

  }
  
  private void utilizePersonEditing()
  {
    
    this.isViewingMode = true;
    
    this.personControlsPayload.familyName.Value = "";
    this.personControlsPayload.givenName.Value = "";
    this.personControlsPayload.familyNameSpell.Value = "";
    this.personControlsPayload.givenNameSpell.Value = "";
    this.personControlsPayload.emailAddress.Value = "";
    // TODO 其の他のフィルド

  }


  /* ━━━ ルーチン ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ * /
  /* ─── ID生成 ────────────────────────────────────────────────────────────────────────────────────────────────────── */
  private static uint counterForComponentID_Generating = 0;

  private static string generateComponentID()
  {
    PersonManager.counterForComponentID_Generating++;
    return $"PERSON_MANAGER-{ PersonManager.counterForComponentID_Generating }";
  }
  
}