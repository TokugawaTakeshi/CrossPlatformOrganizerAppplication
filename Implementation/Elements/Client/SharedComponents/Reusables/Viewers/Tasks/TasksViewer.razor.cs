using Microsoft.AspNetCore.Components;


namespace Client.SharedComponents.Reusables.Viewers.Tasks;


public partial class TasksViewer : ComponentBase 
{

  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
}
