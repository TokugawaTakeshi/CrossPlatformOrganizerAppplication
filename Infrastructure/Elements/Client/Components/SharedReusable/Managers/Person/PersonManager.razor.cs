using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Managers.Person;


public partial class PersonManager : ComponentBase
{

  [Parameter]
  public string spaceSeparatedAdditionalCSS_Classes { get; set; }

  


  /* === ルーチン ====================================================================================================== */
  /* --- ID生成 ------------------------------------------------------------------------------------------------------ */
  private readonly string COMPONENT_ID = PersonManager.generateComponentID();
  private string HEADING_ID => $"{ this.COMPONENT_ID }-HEADING";
  
  private static uint counterForComponentID_Generating = 0;

  private static string generateComponentID()
  {
    PersonManager.counterForComponentID_Generating++;
    return $"PERSON_MANAGER-{ PersonManager.counterForComponentID_Generating }";
  }
  
}