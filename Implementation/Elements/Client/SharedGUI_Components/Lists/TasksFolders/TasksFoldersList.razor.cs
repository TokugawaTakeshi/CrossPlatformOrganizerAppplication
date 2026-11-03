using Client.SharedGUI_Components.Lists.TasksFolders.Localizations;
using CommonSolution.Entities.Task;
using CommonSolution.Restrictions;

namespace Client.SharedGUI_Components.Lists.TasksFolders;


public partial class TasksFoldersList : 
    Microsoft.AspNetCore.Components.ComponentBase, 
    YamatoDaiwa.Frontend.GUI_Components.Abstractions.IHTML_AttributesFallthrough 
{

  /* ━━━ Blazor Component Parameters ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public IEnumerable<TaskCustomFolder> taskCustomFolders { get; set; } = [];
  
  [Microsoft.AspNetCore.Components.Parameter]
  public TaskCustomFolder? initiallySelectedCustomFolder { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.EventCallback<TaskCustomFolder>? onTaskCustomFolderSelected { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues = true)]
  public Dictionary<string, object>? rootElementHTML_Attributes { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.RenderFragment? ChildContent { get; set; }
  
  
  /* ━━━ State ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private string? selectedTaskCustomFolderID = null;


  /* ━━━ Actions Handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private async System.Threading.Tasks.Task onSelectFolderEventHandler(TaskCustomFolder taskCustomFolder)
  {
    this.selectedTaskCustomFolderID = taskCustomFolder.ID;
    await this.onTaskCustomFolderSelected?.InvokeAsync(taskCustomFolder);
  }
  
  
  public TasksFoldersList()
  {

    if (this.initiallySelectedCustomFolder is not null)
    {
      this.selectedTaskCustomFolderID = this.initiallySelectedCustomFolder.ID;
    }
    
  }


  /* ━━━ Localization ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private readonly TasksFoldersListLocalization localization = 
      ClientConfigurationRepresentative.GetBCP_47_Tag_OfSupportedLocale() switch
          {
            SupportedCultures.BCP_47_Tags.JAPANESE => new TasksFoldersListJapaneseLocalization(),
            SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM => new TasksFoldersListEnglishLocalization(),
            _ => throw new ArgumentOutOfRangeException()
          };

}
