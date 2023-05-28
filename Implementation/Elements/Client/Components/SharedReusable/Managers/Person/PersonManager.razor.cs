using Client.Data.FromUser.Entities.Person;
using Client.Data.FromUser.Entities.Task;

using FrontEndFramework.InputtedValueValidation;
using ValidatableControl = FrontEndFramework.ValidatableControl;


namespace Client.Components.SharedReusable.Managers.Person;


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
  
  private (
    ValidatableControl.Payload<string, PersonFamilyNameInputtedDataValidation> familyName, 
    ValidatableControl.Payload<string, PersonGivenNameInputtedDataValidation> givenName
  ) controlsPayload = (
    familyName: new ValidatableControl.Payload<string, PersonFamilyNameInputtedDataValidation>(
      initialValue: "", 
      validation: new PersonFamilyNameInputtedDataValidation()
    ),
    givenName: new ValidatableControl.Payload<string, PersonGivenNameInputtedDataValidation>(
      initialValue: "", 
      validation: new PersonGivenNameInputtedDataValidation()
    )
  );
  

  /* ━━━ 行動処理 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private void beginPersonEditing()
  {

    if (this.targetPerson is null)
    {
      throw new Exception("「beginPersonEditing」メソッドは呼び出されたが、「targetPerson」は「null」のだ。");
    }

    this.controlsPayload.familyName.Value = this.targetPerson.familyName;
    this.controlsPayload.givenName.Value = this.targetPerson.givenName ?? "";
    
    this.isViewingMode = false;
    
  }
  
  private void displayPersonDeletingConfirmationDialog()
  {
    // TODO
  }
  
  private void updatePerson()
  {

    if (this.targetPerson is null)
    {
      throw new Exception("「updatePerson」メソッドは呼び出されたが、「targetPerson」は「null」のだ。");
    }


    if (ValidatableControlsGroup.HasInvalidInputs(this.controlsPayload))
    {
      ValidatableControlsGroup.PointOutValidationErrors(this.controlsPayload);
    }
    
    // TODO そのままでtargetPersonを更新しても良いと思わん。
    
  }
  
  private void utilizePersonEditing()
  {
    
    this.isViewingMode = true;

    this.controlsPayload.familyName.Value = "";
    this.controlsPayload.givenName.Value = "";

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