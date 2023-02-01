using Microsoft.AspNetCore.Components;
using FrontEndFramework.Components.Badge;


namespace Client.Components.SharedReusable.Cards.Task;


public partial class TaskCard : ComponentBase
{

  [Parameter] public CommonSolution.Entities.Task.Task TargetTask { get; set; }
  
  [Parameter] public string SpaceSeparatedAdditionalCSS_Classes { get; set; }
  
  [Parameter] public string RootElementTag { get; set; } = "div";

}