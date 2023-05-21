using System.Diagnostics;
using Client.Data.FromUser.Entities.Task;
using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Managers.Task;


using ValidatableControl = FrontEndFramework.ValidatableControl;


public partial class TaskManager : ComponentBase
{
  
  /* === Blazorコンポーネント引数 ========================================================================================= */
  [Parameter] public CommonSolution.Entities.Task? targetTask { get; set; }

  [Parameter] public string? activationGuidance { get; set; }
  
  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }


  /* === Blazorコンポーネントステート ======================================================================================= */
  private bool isViewingMode = true;
  
  private readonly string ID = TaskManager.generateComponentID();
  private string HEADING_ID => $"{ this.ID }-HEADING";

  private ValidatableControl.Payload taskTitlePayload = new(initialValue: "", new TaskTitleInputtedDataValidation());
  private ValidatableControl.Payload taskDescriptionPayload = new(initialValue: "", new TaskTitleInputtedDataValidation());
  
  
  /* === 行動処理 ==================================================================================================== */
  private void beginTaskEditing()
  {

    if (this.targetTask == null)
    {
      return;
    }


    Debug.WriteLine("CP1");
    // this.taskTitlePayload.Value = this.targetTask.Title;
    // this.taskDescriptionPayload.Value = this.targetTask.Description ?? "";
    
    this.isViewingMode = false;

  }

  private void displayTaskDeletingConfirmationDialog()
  {
    // TODO 【 次のプールリクエスト 】 実装
  }

  private void updateTask()
  {
    // TODO 【 次のプールリクエスト 】 実装
  }

  private void utilizeTaskEditing()
  {
    
    this.isViewingMode = true;

    this.taskTitlePayload.Value = "";
    this.taskDescriptionPayload.Value = "";

  }


  /* === ルーチン ====================================================================================================== */
  /* --- ID生成 ------------------------------------------------------------------------------------------------------ */
  private static uint counterForComponentID_Generating = 0;
  
  private static string generateComponentID()
  {
    TaskManager.counterForComponentID_Generating++;
    return $"TASK_MANAGER-{ TaskManager.counterForComponentID_Generating }";
  }

}