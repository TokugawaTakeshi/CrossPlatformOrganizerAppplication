using Microsoft.AspNetCore.Components;


namespace Client.SharedComponents.Cards.Task;


public partial class TaskCard : Microsoft.AspNetCore.Components.ComponentBase
{

  [Microsoft.AspNetCore.Components.Parameter]
  public required CommonSolution.Entities.Task targetTask { get; set; }

  [Microsoft.AspNetCore.Components.Parameter]
  public EventCallback<CommonSolution.Entities.Task> onClick { get; set; }

  [Microsoft.AspNetCore.Components.Parameter]
  public string rootElementTag { get; set; } = "div";
  
  [Microsoft.AspNetCore.Components.Parameter]
  public string? rootElementModifierCSS_Class { get; set; }


  private async System.Threading.Tasks.Task onClickOutermostElement()
  {

    if (this.onClick.HasDelegate)
    {

      try
      {
        await this.onClick.InvokeAsync(this.targetTask);
      }
      catch (Exception exception)
      {
        Console.WriteLine(exception);
        throw;
      }
      
    }
    
  }
  
}