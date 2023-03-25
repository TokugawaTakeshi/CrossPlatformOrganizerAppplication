using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Cards.Person;


public partial class PersonCard : ComponentBase
{

  [Parameter] public required CommonSolution.Entities.Person TargetPerson { get; set; }
  
  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }
  
  [Parameter] public string RootElementTag { get; set; } = "div";

}
