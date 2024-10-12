using Client.SharedGUI_Components.Lists.TasksFolders.Item.Localizations;
using CommonSolution.Entities.Task;
using CommonSolution.Restrictions;
using YamatoDaiwa.CSharpExtensions;
using YamatoDaiwa.Frontend.Helpers;

namespace Client.SharedGUI_Components.Lists.TasksFolders.Item;


public partial class TasksFoldersListItem : 
    Microsoft.AspNetCore.Components.ComponentBase,
    YamatoDaiwa.Frontend.GUI_Components.Abstractions.IHTML_AttributesFallthrough 
{

  /* ━━━ Blazor Component Parameters ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public TaskCustomFolder? taskCustomFolder { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public string? label { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public string? accessibilityGuidance { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public bool isSelected { get; set; } = false;
  
  [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues = true)]
  public Dictionary<string, object>? rootElementHTML_Attributes { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.RenderFragment? ChildContent { get; set; }
  
  
  /* ┅┅┅ Events ┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅┅ */
  [Microsoft.AspNetCore.Components.Parameter] 
  public Microsoft.AspNetCore.Components.EventCallback? onInteractiveLabelClickedInViewingModeEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.EventCallback<TaskCustomFolder>? onSelectFolderEventHandler { get; set; }
  
  
  /* ━━━ State ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private bool isChildrenListExpanded = false;
  
  private bool isPopupMenuDisplaying = false;  
  
  private bool isEditingMode = false;
  
  private bool isViewingMode => !this.isEditingMode;
  
  
  /* ━━━ Localization ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private readonly TasksFoldersListItemLocalization localization = 
      ClientConfigurationRepresentative.GetBCP_47_Tag_OfSupportedLocale() switch
          {
            SupportedCultures.BCP_47_Tags.JAPANESE => new TasksFoldersListItemJapaneseLocalization(),
            SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM => new TasksFoldersListItemEnglishLocalization(),
            _ => throw new ArgumentOutOfRangeException()
          };
  
  
  /* ━━━ Actions Handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private void onInteractiveLabelClickedInViewingMode()
  {
    
    if (this.isSelected)
    {
      return;
    }
    
    
    this.onInteractiveLabelClickedInViewingModeEventHandler?.InvokeAsync();

    if (this.taskCustomFolder is not null)
    {
      this.onSelectFolderEventHandler?.InvokeAsync(this.taskCustomFolder);
    }
    
  }
  
  private void onExpandingToggleClicked()
  {
    System.Diagnostics.Debug.WriteLine("onExpandingToggleClicked");
    this.isChildrenListExpanded = !this.isChildrenListExpanded;
  }
  
  private void onInteractiveLabelClickedTwiceInViewingMode()
  {
    System.Diagnostics.Debug.WriteLine("Double click"); 
  }
  
  private void onMenuDisplayingToggleClicked()
  {
    this.isPopupMenuDisplaying = !this.isPopupMenuDisplaying;
  }
  
  private void onTaskCustomFolderRenamingButtonClicked()
  {
    this.isEditingMode = true;
  }
  
  private void onTaskCustomFolderDeletingButtonClicked()
  {
    System.Diagnostics.Debug.WriteLine("DELETE");
  }
  
  
  /* ━━━ Rendering ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private string getClassAttributeValueForRootElement(string CSS_Namespace)
  {
    return YDF_ComponentsHelper.GenerateClassAttributeValueForRootElement(
      new YDF_ComponentsHelper.SettingsForGeneratingOfClassAttributeValueForRootElement
      {
        CSS_Namespace = CSS_Namespace,
        rootElementHTML_Attributes = this.rootElementHTML_Attributes,
        otherInternalCSS_Classes = new List<string>().AddElementToEndIf($"{ CSS_Namespace }__Selected", this.isSelected)
      }
    );
  }
  
}
