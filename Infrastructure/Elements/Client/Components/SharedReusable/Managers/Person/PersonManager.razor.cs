using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Managers.Person;


public partial class PersonManager : ComponentBase
{

  [Parameter]
  public string SpaceSeparatedAdditionalCSS_Classes { get; set; }
  
}