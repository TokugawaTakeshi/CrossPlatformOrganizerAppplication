using Microsoft.AspNetCore.Components;

namespace Client.Components.SharedReusable.Managers.Task;


public partial class TaskManager : ComponentBase
{

  [Parameter]
  public string spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  [Parameter]
  public CommonSolution.Entities.Task.Task? targetTask { get; set; }

  [Parameter] 
  public string? activationGuidance { get; set; }


  private bool isViewingMode = true;
  
  private string ID = TaskManager.generateComponentID();
  private string HEADING_ID => $"{ this.ID }-HEADING";
  
  
  /* === 行動処理 ==================================================================================================== */
  private void beginTaskEditing()
  {
    this.isViewingMode = false;
  }

  private void displayTaskDeletingConfirmationDialog()
  {
    // TODO
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