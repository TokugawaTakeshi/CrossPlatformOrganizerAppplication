using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Managers.Task;


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
  
  
  /* === 行動処理 ==================================================================================================== */
  private void beginTaskEditing()
  {
    this.isViewingMode = false;
    // TODO 【 次のプールリクエスト 】 実装
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