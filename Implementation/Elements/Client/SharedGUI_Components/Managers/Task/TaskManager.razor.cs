using CommonSolution.Gateways.Task;
using CommonSolution.Restrictions;
using Client.SharedGUI_Components.Managers.Task.Localizations;
using Client.Data.FromUser.Entities.Task;
using FrontEndFramework.Components.ModalDialogs.Confirmation;
using YamatoDaiwa.Frontend.GUI_Components.Controls.Validatables.TextBox;
using YamatoDaiwa.Frontend.GUI_Components.Controls.Validation;

namespace Client.SharedGUI_Components.Managers.Task;


public partial class TaskManager : Microsoft.AspNetCore.Components.ComponentBase
{
  
  /* ━━━ Component Parameters ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter] 
  public CommonSolution.Entities.Task.Task? targetTask { get; set; }

  [Microsoft.AspNetCore.Components.Parameter]
  [Microsoft.AspNetCore.Components.EditorRequired]
  public required Microsoft.AspNetCore.Components.EventCallback<
    TaskGateway.Adding.RequestData
  > onSaveNewTaskEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  [Microsoft.AspNetCore.Components.EditorRequired]
  public required Microsoft.AspNetCore.Components.EventCallback<
    TaskGateway.Updating.RequestData
  > onSaveUpdatedTaskEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter] 
  [Microsoft.AspNetCore.Components.EditorRequired]
  public required Microsoft.AspNetCore.Components.EventCallback<
    CommonSolution.Entities.Task.Task
  > onDeleteSelectedTaskEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  [Microsoft.AspNetCore.Components.EditorRequired]
  public required string activationGuidance { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues = true)]
  public Dictionary<string, object>? rootElementHTML_Attributes { get; set; } 
  
  
  /* ━━━ Fields ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ┅┅┅ Payload ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private readonly (
    YamatoDaiwa.Frontend.GUI_Components.Controls.Validatables.ValidatableControl.Payload title, 
    YamatoDaiwa.Frontend.GUI_Components.Controls.Validatables.ValidatableControl.Payload description
  ) taskControlsPayload;
  
  /* ┅┅┅ Controls ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private TextBox titleTextBox = null!;
  private TextBox descriptionTextBox = null!;
  
  /* ┅┅┅ Modes ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private TextBox.ValidityHighlightingActivationModes validityHighlightingActivationMode => 
      this.targetTask is null ?
        TextBox.ValidityHighlightingActivationModes.onFocusOut :
        TextBox.ValidityHighlightingActivationModes.immediate;

  private bool isViewingMode = true;
  private bool isEditingMode => !this.isViewingMode;
  
  
  /* ┅┅┅ IDs ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private readonly string ID = TaskManager.generateComponentID();
  private readonly string HEADING_ID;
  
  
  /* ┅┅┅ Localization ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private readonly TaskManagerLocalization localization = 
      ClientConfigurationRepresentative.GetBCP_47_Tag_OfSupportedLocale() switch
          {
            SupportedCultures.BCP_47_Tags.JAPANESE => new TaskManagerJapaneseLocalization(),
            SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM => new TaskManagerEnglishLocalization(),
            _ => throw new ArgumentOutOfRangeException()
          };


  /* ━━━ Constructor ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public TaskManager()
  {
    
    this.HEADING_ID = $"{ this.ID }-HEADING";
    
    this.taskControlsPayload = (
      title: new YamatoDaiwa.Frontend.GUI_Components.Controls.Validatables.ValidatableControl.Payload(
        initialValue: this.targetTask?.title ?? "", 
        validation: new TaskTitleInputtedDataValidation(),
        componentInstanceAccessor: () => this.titleTextBox
      ),
      description: new YamatoDaiwa.Frontend.GUI_Components.Controls.Validatables.ValidatableControl.Payload(
        initialValue: this.targetTask?.description ?? "", 
        validation: new TaskDescriptionInputtedDataValidation(),
        componentInstanceAccessor: () => this.descriptionTextBox
      ) 
    );
    
  }


  /* ━━━ Public Methods ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public void utilizeTaskEditingSession()
  {
    
    this.isViewingMode = true;

    this.taskControlsPayload.title.SetValue("");
    this.taskControlsPayload.description.SetValue("");

  }

  
  /* ━━━ Actions Handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  public void startInputOfNewTaskData()
  {
    this.isViewingMode = false;
  }
  
  private void startEditionOfSelectedTask()
  {

    if (this.targetTask is null)
    {
      
      System.Diagnostics.Debug.WriteLine(
        "\"startEditionOfSelectedTask\" has been called while \"targetTask\" is still \"null\"."
      );
      
      return;
      
    }


    this.taskControlsPayload.title.SetValue(this.targetTask.title);
    this.taskControlsPayload.description.SetValue(this.targetTask.description ?? ""); 
    
    this.isViewingMode = false;

  }

  private void displayTaskDeletingConfirmationDialog()
  {
    ConfirmationModalDialogService.displayModalDialog(
      new ConfirmationModalDialog.Options
      {
        title = this.localization.taskDeletingConfirmationModalDialog.title,
        question = this.localization.taskDeletingConfirmationModalDialog.question,
        onConfirmationButtonClickedEventHandler = () => _ = this.deleteTask()
      }  
    );
  }

  private async System.Threading.Tasks.Task onTaskDataSavingButtonClicked()
  {

    if (ValidatableControlsGroup.HasInvalidInputs(this.taskControlsPayload))
    {
      ValidatableControlsGroup.PointOutValidationErrors(this.taskControlsPayload);
      return;
    }
    

    if (this.targetTask == null)
    {

      await this.onSaveNewTaskEventHandler.InvokeAsync(
        new TaskGateway.Adding.RequestData
        {
          Title = this.taskControlsPayload.title.GetExpectedToBeValidValue<string>(),
          Description = this.taskControlsPayload.description.GetExpectedToBeValidValue<string>()
        }
      );
      
      return;

    }
    
    
    await this.onSaveUpdatedTaskEventHandler.InvokeAsync(
      new TaskGateway.Updating.RequestData
      {
        ID = this.targetTask.ID,
        Title = this.taskControlsPayload.title.GetExpectedToBeValidValue<string>(),
        Description = this.taskControlsPayload.description.GetExpectedToBeValidValue<string>()
      }
    );

  }

  private async System.Threading.Tasks.Task deleteTask()
  {

    if (this.targetTask is null)
    {
       System.Diagnostics.Debug.WriteLine(
        "\"deleteTask\" method has been called while \"targetTask\" is still \"null\"."
      );
    }

    
    await this.onDeleteSelectedTaskEventHandler.InvokeAsync(this.targetTask);

  }
  
  
  /* ━━━ Routines ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  /* ┅┅┅ Generating of ID ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  private static uint counterForComponentID_Generating = 0;
  
  private static string generateComponentID()
  {
    TaskManager.counterForComponentID_Generating++;
    return $"TASK_MANAGER-{ TaskManager.counterForComponentID_Generating }";
  }
  
}