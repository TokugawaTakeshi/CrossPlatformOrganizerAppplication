using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Managers.Task;


public partial class TaskManager : ComponentBase
{

  [Parameter]
  public string SpaceSeparatedAdditionalCSS_Classes { get; set; }
  
}