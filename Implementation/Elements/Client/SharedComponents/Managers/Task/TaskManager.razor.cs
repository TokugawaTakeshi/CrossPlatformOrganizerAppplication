using System.Diagnostics;
using Client.Data.FromUser.Entities.Task;

using FrontEndFramework.Components.Controls.TextBox;
using FrontEndFramework.InputtedValueValidation;

using ValidatableControl = FrontEndFramework.ValidatableControl;


namespace Client.SharedComponents.Managers.Task;


public partial class TaskManager : Microsoft.AspNetCore.Components.ComponentBase
{
  
  /* ━━━ Blazorコンポーネント引数 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter] 
  public CommonSolution.Entities.Task? targetTask { get; set; }

  [Microsoft.AspNetCore.Components.Parameter] 
  public required Microsoft.AspNetCore.Components.EventCallback<
    CommonSolution.Gateways.ITaskGateway.Adding.RequestData
  > onInputtingDataOfNewTaskComplete { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public required Microsoft.AspNetCore.Components.EventCallback<
    CommonSolution.Gateways.ITaskGateway.Updating.RequestData
  > onExistingTaskEditingComplete { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public required string activationGuidance { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  public string? rootElementModifierCSS_Class { get; set; }


  /* ━━━ ステート ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private bool isViewingMode = true;
  private bool isEditingMode => !this.isViewingMode;
  
  private readonly string ID = TaskManager.generateComponentID();
  private string HEADING_ID => $"{ this.ID }-HEADING";

  
  private TextBox titleTextBox = null!;
  private TextBox descriptionTextBox = null!;
  
  private (
    ValidatableControl.Payload title, 
    ValidatableControl.Payload description
  ) taskControlsPayload;
  
  
  /* ━━━ コンストラクタ ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public TaskManager()
  {
    this.taskControlsPayload = (
      title: new ValidatableControl.Payload(
        initialValue: "", 
        validation: new TaskTitleInputtedDataValidation(),
        componentInstanceAccessor: () => this.titleTextBox
      ),
      description: new ValidatableControl.Payload(
        initialValue: "", 
        validation: new TaskDescriptionInputtedDataValidation(),
        componentInstanceAccessor: () => this.descriptionTextBox
      ) 
    );
  }

  
  /* ━━━ 行動処理 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── 新規課題追加 ───────────────────────────────────────────────────────────────────────────────────────────────────── */
  public void beginInputNewTaskData()
  {
    this.isViewingMode = false;
  }
  
  private void beginTaskEditing()
  {

    if (this.targetTask is null)
    {
      throw new Exception("「beginTaskEditing」メソッドは呼び出されたが、「targetTask」は「null」のまま。");
    }


    this.taskControlsPayload.title.Value = this.targetTask.title;
    this.taskControlsPayload.description.Value = this.targetTask.description ?? ""; 
    
    this.isViewingMode = false;

  }

  private void displayTaskDeletingConfirmationDialog()
  {
    // TODO
  }

  
  /* ─── 新規追加・編集 ──────────────────────────────────────────────────────────────────────────────────────────────────── */
  async private void onClickTaskDataSavingButton()
  {

    if (ValidatableControlsGroup.HasInvalidInputs(this.taskControlsPayload))
    {
      ValidatableControlsGroup.PointOutValidationErrors(this.taskControlsPayload);
      return;
    }
    
    
    try
    {

      if (this.targetTask == null)
      {

        await this.onInputtingDataOfNewTaskComplete.InvokeAsync(
          new CommonSolution.Gateways.ITaskGateway.Adding.RequestData
          {
            Title = this.taskControlsPayload.title.GetExpectedToBeValidValue<string>(),
            Description = this.taskControlsPayload.description.GetExpectedToBeValidValue<string>()
          }
        );

      }
      else
      {
      
        await this.onExistingTaskEditingComplete.InvokeAsync(
          new CommonSolution.Gateways.ITaskGateway.Updating.RequestData
          {
            ID = this.targetTask.ID,
            Title = this.taskControlsPayload.title.GetExpectedToBeValidValue<string>(),
            Description = this.taskControlsPayload.description.GetExpectedToBeValidValue<string>()
          }
        );
        
      }

    }
    finally
    {
      this.utilizeTaskEditing();      
    }

  }

  private void utilizeTaskEditing()
  {
    
    this.isViewingMode = true;

    this.taskControlsPayload.title.Value = "";
    this.taskControlsPayload.description.Value = "";

  }
  
  
  /* ━━━ ルーチン ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ─── ID生成 ─────────────────────────────────────────────────────────────────────────────────────────────────────── */
  private static uint counterForComponentID_Generating = 0;
  
  private static string generateComponentID()
  {
    TaskManager.counterForComponentID_Generating++;
    return $"TASK_MANAGER-{ TaskManager.counterForComponentID_Generating }";
  }

}