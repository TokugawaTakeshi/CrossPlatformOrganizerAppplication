using Microsoft.AspNetCore.Components;


namespace Client.SharedComponents.Reusables.Cards.Task;


public partial class TaskCard : ComponentBase
{

  [Parameter] public required CommonSolution.Entities.Task targetTask { get; set; }

  [Parameter] public EventCallback<CommonSolution.Entities.Task> onClick { get; set; }

  [Parameter] public string rootElementTag { get; set; } = "div";
  
  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }


  private async System.Threading.Tasks.Task onClickOutermostElement()
  {
    await this.onClick.InvokeAsync(this.targetTask);
  }
  
}