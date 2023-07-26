using Client.Data.FromUser.Entities.Person;
using FrontEndFramework.Components.Controls.TextBox;
using FrontEndFramework.InputtedValueValidation;
using ValidatableControl = FrontEndFramework.ValidatableControl;


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

  private (
    ValidatableControl.Payload familyName,
    ValidatableControl.Payload givenName,
    ValidatableControl.Payload familyNameSpell,
    ValidatableControl.Payload givenNameSpell
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
    
    // TODO https://github.com/TokugawaTakeshi/ExperimentalCSharpApplication1/issues/55
    // this.targetPerson.familyName = this.controlsPayload.familyName.GetExpectedToBeValidValue();
    // TODO そのままでtargetPersonを更新しても良いと思わん。

  }
  
  private void utilizePersonEditing()
  {
    
    this.isViewingMode = true;
    
    this.controlsPayload.familyName.Value = "";
    this.controlsPayload.givenName.Value = "";
    this.controlsPayload.familyNameSpell.Value = "";
    this.controlsPayload.givenNameSpell.Value = "";

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