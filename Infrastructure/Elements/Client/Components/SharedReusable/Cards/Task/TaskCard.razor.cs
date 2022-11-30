using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Cards.Task;


public partial class TaskCard : ComponentBase
{

  [Parameter] public BusinessRules.Enterprise.Tasks.Task TargetTask { get; set; }
  
  [Parameter] public string RootElementTag { get; set; } = "div";
  
}