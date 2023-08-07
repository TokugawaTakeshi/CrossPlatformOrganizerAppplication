using System.Diagnostics;


namespace Client.SharedComponents.Reusables.Cards.Person;


public partial class PersonCard : Microsoft.AspNetCore.Components.ComponentBase
{

  [Microsoft.AspNetCore.Components.Parameter] 
  public required CommonSolution.Entities.Person targetPerson { get; set; }

  [Microsoft.AspNetCore.Components.Parameter]
  public Microsoft.AspNetCore.Components.EventCallback<CommonSolution.Entities.Person> onClick { get; set; }

  [Microsoft.AspNetCore.Components.Parameter] 
  public string rootElementTag { get; set; } = "div";

  [Microsoft.AspNetCore.Components.Parameter]
  public string? spaceSeparatedAdditionalCSS_Classes { get; set; } = null;
  
  
  private async System.Threading.Tasks.Task onClickOutermostElement()
  {

    try
    {
      await this.onClick.InvokeAsync(this.targetPerson);
    }
    catch (Exception exception)
    {
      // TODO 修正　現在問い合わせ中（https://stackoverflow.com/q/76882558/4818123）
      Debug.WriteLine("Catch the exception");
      Console.WriteLine(exception);
      throw;
    }
    
  }

}
