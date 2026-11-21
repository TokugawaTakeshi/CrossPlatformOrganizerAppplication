using Client.SharedGUI_Components.Cards.Task.Localizations;
using CommonSolution.Restrictions;
using YamatoDaiwa.CSharpExtensions;

namespace Client.SharedGUI_Components.Cards.Task;


public partial class TaskCard : 
    Microsoft.AspNetCore.Components.ComponentBase,
    YamatoDaiwa.Frontend.GUI_Components.Abstractions.IHTML_AttributesFallthrough
{

  /* ━━━ Component Parameters ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public required CommonSolution.Entities.Task.Task targetTask { get; set; }

  [Microsoft.AspNetCore.Components.Parameter]
  public required Microsoft.AspNetCore.Components.EventCallback<
    CommonSolution.Entities.Task.Task
  > onRootElementClickedEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public required Microsoft.AspNetCore.Components.EventCallback<
    CommonSolution.Entities.Task.Task
  > onCheckBoxClickedEventHandler { get; set; }

  [Microsoft.AspNetCore.Components.Parameter]
  public string rootElementTag { get; set; } = "div";
  
  [Microsoft.AspNetCore.Components.Parameter]
  public bool disabled { get; set; } = false;
  
  [Microsoft.AspNetCore.Components.Parameter(CaptureUnmatchedValues = true)]
  public Dictionary<string, object>? rootElementHTML_Attributes { get; set; }
  
  
  /* ━━━ Fields ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private readonly TaskCardLocalization localization = 
      ClientConfigurationRepresentative.GetBCP_47_Tag_OfSupportedLocale() switch
          {
            SupportedCultures.BCP_47_Tags.JAPANESE => new TaskCardJapaneseLocalization(),
            SupportedCultures.BCP_47_Tags.ENGLISH__UNITED_KINGDOM => new TaskCardEnglishLocalization(),
            _ => throw new ArgumentOutOfRangeException()
          };

  
  /* ━━━ Getters ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private string? dateBadgeLabel => this.targetTask.deadlineDate?.ToString();
  private string? dateTimeBadgeLabel => this.targetTask.deadlineDateTime?.ToString();

  private bool hasAtLeastOneBadge => this.dateBadgeLabel is not null || this.dateTimeBadgeLabel is not null;
  

  /* ━━━ Events Handling ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private async System.Threading.Tasks.Task onClickRootElement()
  {
    if (this.onRootElementClickedEventHandler.HasDelegate)
    {
      try
      {
        await this.onRootElementClickedEventHandler.InvokeAsync(this.targetTask);
      }
      catch (Exception exception)
      {
        
        #if DEBUG
          System.Diagnostics.Debug.WriteLine(exception);
        #endif
        
        throw;
        
      }
    }
  }

  private async System.Threading.Tasks.Task onClickCheckbox()
  {
    if (this.onRootElementClickedEventHandler.HasDelegate)
    {
      try
      {
        await this.onCheckBoxClickedEventHandler.InvokeAsync(this.targetTask);
      }
      catch (Exception exception)
      {
        
        #if DEBUG
          System.Diagnostics.Debug.WriteLine(exception);
        #endif
        
        throw;
        
      }
    }
  }
  
  
  /* ━━━ CSS Classes ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private string composeClassAttributeValueForRootElement(string namespaceCSS_Class) => 
    
      new List<string?> { namespaceCSS_Class }.

          AddElementToEndIfNotNull(
            this.rootElementHTML_Attributes?.TryGetValue("class", out object? CSS_Class) == true ? CSS_Class.ToString() : null
          ).
    
          AddElementToEndIf("TaskCard__DisabledState", this.disabled).

          StringifyEachElementAndJoin(" ");
  
}