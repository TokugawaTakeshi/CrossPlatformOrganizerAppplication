using System.Diagnostics;
using FrontEndFramework.Components.Abstractions;
using FrontEndFramework.Components.Badge;
using Microsoft.AspNetCore.Components;
using Utils;
using YamatoDaiwaCS_Extensions;


namespace Client.SharedComponents.Cards.Task;


public partial class TaskCard : Microsoft.AspNetCore.Components.ComponentBase
{

  [Microsoft.AspNetCore.Components.Parameter]
  public required CommonSolution.Entities.Task targetTask { get; set; }

  [Microsoft.AspNetCore.Components.Parameter]
  public required EventCallback<CommonSolution.Entities.Task> onClickRootElementEventHandler { get; set; }
  
  [Microsoft.AspNetCore.Components.Parameter]
  public required EventCallback<CommonSolution.Entities.Task> onClickCheckboxEventHandler { get; set; }

  [Microsoft.AspNetCore.Components.Parameter]
  public string rootElementTag { get; set; } = "div";
  
  [Microsoft.AspNetCore.Components.Parameter]
  public bool disabled { get; set; } = false;


  /* ━━━ 行動処理 ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private async System.Threading.Tasks.Task onClickRootElement()
  {

    try
    {
      await this.onClickRootElementEventHandler.InvokeAsync(this.targetTask);
    }
    catch (Exception exception)
    {
      Debug.WriteLine(exception);
      throw;
    }
    
  }

  private async System.Threading.Tasks.Task onClickCheckbox()
  {

    try
    {
      await this.onClickCheckboxEventHandler.InvokeAsync(this.targetTask);
    }
    catch (Exception exception)
    {
      Debug.WriteLine(exception);
      throw;
    }

  }


  /* ━━━ 補助ゲッター ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  private string? dateBadgeLabel => this.targetTask.associatedDate?.ToString();
  private string? dateTimeBadgeLabel => this.targetTask.associatedDateTime?.ToString();

  private bool hasAtLeastOneBadge => this.dateBadgeLabel is not null || this.dateTimeBadgeLabel is not null;
  
  
  /* ━━━ CSSクラス ━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ */
  [Microsoft.AspNetCore.Components.Parameter]
  public string? rootElementModifierCSS_Class { get; set; } = null;
  
  private string rootElementModifierCSS_Classes => new List<string>().
    
      AddElementToEndIf("TaskCard__DisabledState", this.disabled).
      AddElementToEndIf(
        this.rootElementModifierCSS_Class ?? "", String.IsNullOrEmpty(this.rootElementModifierCSS_Class)
      ).
          
      StringifyEachElementAndJoin(" ");

}