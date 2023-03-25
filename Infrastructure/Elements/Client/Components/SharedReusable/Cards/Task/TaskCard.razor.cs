using System.Diagnostics;
using Microsoft.AspNetCore.Components;
using FrontEndFramework.Components.Badge;


namespace Client.Components.SharedReusable.Cards.Task;


public partial class TaskCard : ComponentBase
{

  [Parameter] public required CommonSolution.Entities.Task.Task TargetTask { get; set; }
  
  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  [Parameter] public string RootElementTag { get; set; } = "div";

  [Parameter] public EventCallback<CommonSolution.Entities.Task.Task> onClick { get; set; }


  private async System.Threading.Tasks.Task onClickOutermostElement()
  {
    await this.onClick.InvokeAsync(this.TargetTask);
  }
  
}