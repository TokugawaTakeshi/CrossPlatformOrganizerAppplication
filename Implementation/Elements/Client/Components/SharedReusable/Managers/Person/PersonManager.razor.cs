using Microsoft.AspNetCore.Components;


namespace Client.Components.SharedReusable.Managers.Person;


public partial class PersonManager : ComponentBase
{
  
  /* === Blazorコンポーネント引数 ========================================================================================= */
  [Parameter] public CommonSolution.Entities.Person? targetPerson { get; set; }

  [Parameter] public string? activationGuidance { get; set; }
  
  [Parameter] public string? spaceSeparatedAdditionalCSS_Classes { get; set; }

  
  /* === Blazorコンポーネントステート ======================================================================================= */
  private bool isViewingMode = true;
  
  private readonly string ID = PersonManager.generateComponentID();
  private string HEADING_ID => $"{ this.ID }-HEADING";
  
  
  /* === 行動処理 ==================================================================================================== */
  private void beginPersonEditing()
  {
    this.isViewingMode = false;
    // TODO 【 次のプールリクエスト 】 実装
  }
  
  private void displayPersonDeletingConfirmationDialog()
  {
    // TODO 【 次のプールリクエスト 】 実装
  }
  
  private void updatePerson()
  {
    // TODO 【 次のプールリクエスト 】 実装
  }
  
  private void utilizePersonEditing()
  {
    this.isViewingMode = true;
  }
  

  /* === ルーチン ====================================================================================================== */
  /* --- ID生成 ------------------------------------------------------------------------------------------------------ */
  private static uint counterForComponentID_Generating = 0;

  private static string generateComponentID()
  {
    PersonManager.counterForComponentID_Generating++;
    return $"PERSON_MANAGER-{ PersonManager.counterForComponentID_Generating }";
  }
  
}