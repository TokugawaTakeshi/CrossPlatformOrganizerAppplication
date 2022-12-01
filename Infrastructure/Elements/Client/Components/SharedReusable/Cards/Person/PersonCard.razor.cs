using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Cards.Person;


public partial class PersonCard : ComponentBase
{

  [Parameter] public BusinessRules.Enterprise.Person TargetPerson { get; set; }
  
  [Parameter] public string SpaceSeparatedAdditionalCSS_Classes { get; set; }
  
  [Parameter] public string RootElementTag { get; set; } = "div";

}
