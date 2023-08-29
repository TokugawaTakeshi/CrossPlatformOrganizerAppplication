using Microsoft.AspNetCore.Components;


namespace Client.SharedComponents.Managers.Task;


public partial class TaskManager : Microsoft.AspNetCore.Components.ComponentBase
{
  
  /* ━━━ Blazorコンポーネント引数 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter] 
  public CommonSolution.Entities.Task? targetTask { get; set; }

  [Microsoft.AspNetCore.Components.Parameter] 
  public string? activationGuidance { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public string? rootElementModifierCSS_Class { get; set; }


  /* ━━━ ステート ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private bool isViewingMode = true;
  private bool isEditingMode => !this.isViewingMode;
  
  private readonly string ID = TaskManager.generateComponentID();
  private string HEADING_ID => $"{ this.ID }-HEADING";

  // === TODO 再開点 ====================================================================================================  
  /* === 行動処理 ==================================================================================================== */
  private void beginTaskEditing()
  {

    if (this.targetTask is null)
    {
      throw new Exception("「beginTaskEditing」メソッドは呼び出されたが、「targetTask」は「null」のだ。");
    }

    this.isViewingMode = false;

  }

  private void displayTaskDeletingConfirmationDialog()
  {
    // TODO 【 次のプールリクエスト 】 実装
  }

  private void updateTask()
  {

    if (this.targetTask == null)
    {
      throw new Exception("「updateTask」メソッドは呼び出されたが、「targetTask」は「null」のまま。");
    }
    
    // if (ValidatableControlsGroup.HasInvalidInputs(this.controlsPayload))
    // {
    //   // ValidatableControlsGroup.PointOutValidationErrors();
    //   return;
    // }

    // this.targetTask.title = this.controlsPayload.taskTitle.GetExpectedToBeValidValue();
    // this.targetTask.description = this.controlsPayload.taskDescription.GetExpectedToBeValidValue();
    
    // TODO 【 次のプールリクエスト 】 実装
  }

  private void utilizeTaskEditing()
  {
    
    this.isViewingMode = true;

    // this.controlsPayload.taskTitle.Value = "";
    // this.controlsPayload.taskDescription.Value = "";

  }
  
  // === TODO  未整理 ====================================================================================================
  
  
  /* === ルーチン ====================================================================================================== */
  /* --- ID生成 ------------------------------------------------------------------------------------------------------ */
  private static uint counterForComponentID_Generating = 0;
  
  private static string generateComponentID()
  {
    TaskManager.counterForComponentID_Generating++;
    return $"TASK_MANAGER-{ TaskManager.counterForComponentID_Generating }";
  }

}